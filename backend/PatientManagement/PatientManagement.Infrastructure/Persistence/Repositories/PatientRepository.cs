using Dapper;
using Microsoft.Extensions.Caching.Memory;
using PatientManagement.Application.Common.Interfaces;
using PatientManagement.Domain.Entities;
using PatientManagement.Infrastructure.Persistence.ConnectionFactory;

namespace PatientManagement.Infrastructure.Persistence.Repositories
{
    public class PatientRepository : IPatientRepository
    {
        private readonly IDbConnectionFactory _connectionFactory;
        private readonly IMemoryCache _memoryCache;
        private const string PatientsCacheKey = "patients_list";

        public PatientRepository(IDbConnectionFactory connectionFactory, IMemoryCache memoryCache)
        {
            _connectionFactory = connectionFactory;
            _memoryCache = memoryCache;
        }

        public async Task<int> UpsertAsync(Patient patient, CancellationToken cancellationToken)
        {
            const string sql = @"
            IF (@PatientId = 0)
            BEGIN
                INSERT INTO dbo.Patients
                (
                    FirstName,
                    LastName,
                    Gender,
                    DateOfBirth,
                    MobileNumber,
                    Email,
                    Address,
                    BloodGroup
                )
                VALUES
                (
                    @FirstName,
                    @LastName,
                    @Gender,
                    @DateOfBirth,
                    @MobileNumber,
                    @Email,
                    @Address,
                    @BloodGroup
                );

                SELECT CAST(SCOPE_IDENTITY() AS INT);
            END
            ELSE
            BEGIN
                UPDATE dbo.Patients
                SET
                    FirstName = @FirstName,
                    LastName = @LastName,
                    Gender = @Gender,
                    DateOfBirth = @DateOfBirth,
                    MobileNumber = @MobileNumber,
                    Email = @Email,
                    Address = @Address,
                    BloodGroup = @BloodGroup,
                    ModifiedDate = SYSUTCDATETIME()
                WHERE PatientId = @PatientId
                    AND IsActive = 1;

                SELECT @PatientId;
            END";

            using var connection = _connectionFactory.CreateConnection();

            int patientId = await connection.ExecuteScalarAsync<int>(
                sql,
                new
                {
                    patient.PatientId,
                    patient.FirstName,
                    patient.LastName,
                    Gender = (byte)patient.Gender,
                    patient.DateOfBirth,
                    patient.MobileNumber,
                    patient.Email,
                    patient.Address,
                    patient.BloodGroup
                });

            _memoryCache.Remove($"{PatientsCacheKey}_{null}_1_10");

            return patientId;
        }

        public async Task<IEnumerable<Patient>> GetAllAsync(string? search, int pageNumber, int pageSize, CancellationToken cancellationToken)
        {
            string cacheKey = $"{PatientsCacheKey}_{search}_{pageNumber}_{pageSize}";

            if (_memoryCache.TryGetValue(cacheKey, out IEnumerable<Patient>? cachedPatients))
            {
                return cachedPatients!;
            }

            const string sql = @"
            SELECT
                PatientId,
                FirstName,
                LastName,
                Gender,
                DateOfBirth,
                MobileNumber,
                Email,
                Address,
                BloodGroup,
                CreatedDate,
                ModifiedDate,
                IsActive
            FROM dbo.Patients
            WHERE
                IsActive = 1
                AND
                (
                    @Search IS NULL
                    OR FirstName LIKE '%' + @Search + '%'
                    OR LastName LIKE '%' + @Search + '%'
                    OR MobileNumber LIKE '%' + @Search + '%'
                )
            ORDER BY PatientId DESC
            OFFSET (@Offset) ROWS
            FETCH NEXT @PageSize ROWS ONLY;";

            using var connection = _connectionFactory.CreateConnection();

            var patients = (await connection.QueryAsync<Patient>(
                sql,
                new
                {
                    Search = string.IsNullOrWhiteSpace(search) ? null : search,
                    Offset = (pageNumber - 1) * pageSize,
                    PageSize = pageSize
                })).ToList();

            _memoryCache.Set(
                cacheKey,
                patients,
                TimeSpan.FromMinutes(5));

            return patients;
        }

        public async Task<Patient?> GetByIdAsync(int patientId, CancellationToken cancellationToken)
        {
            const string sql = @"
            SELECT
                PatientId,
                FirstName,
                LastName,
                Gender,
                DateOfBirth,
                MobileNumber,
                Email,
                Address,
                BloodGroup,
                CreatedDate,
                ModifiedDate,
                IsActive
            FROM dbo.Patients
            WHERE PatientId = @PatientId
            AND IsActive = 1;";

            using var connection = _connectionFactory.CreateConnection();

            return await connection.QueryFirstOrDefaultAsync<Patient>(
                sql,
                new { PatientId = patientId });
        }

        public async Task<bool> DeleteAsync(int patientId, CancellationToken cancellationToken)
        {
            const string sql = @"
            UPDATE dbo.Patients
            SET
                IsActive = 0,
                ModifiedDate = SYSUTCDATETIME()
            WHERE
                PatientId = @PatientId
                AND IsActive = 1;";

            using var connection = _connectionFactory.CreateConnection();

            int rowsAffected = await connection.ExecuteAsync(sql, new
            {
                PatientId = patientId
            });

            _memoryCache.Remove($"{PatientsCacheKey}_{null}_1_10");

            return rowsAffected > 0;
        }
    }
}
