using Dapper;
using PatientManagement.Application.Common.Interfaces;
using PatientManagement.Domain.Entities;
using PatientManagement.Infrastructure.Persistence.ConnectionFactory;

namespace PatientManagement.Infrastructure.Persistence.Repositories
{
    public class PatientRepository : IPatientRepository
    {
        private readonly IDbConnectionFactory _connectionFactory;

        public PatientRepository(IDbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
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

            return patientId;
        }

        public Task<IEnumerable<Patient>> GetAllAsync(string? search, int pageNumber, int pageSize, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<Patient?> GetByIdAsync(int patientId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int patientId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
