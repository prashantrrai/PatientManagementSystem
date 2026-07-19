using PatientManagement.Domain.Entities;

namespace PatientManagement.Application.Common.Interfaces
{
    public interface IPatientRepository
    {
        Task<int> UpsertAsync(Patient patient, CancellationToken cancellationToken);

        Task<IEnumerable<Patient>> GetAllAsync(string? search, int pageNumber, int pageSize, CancellationToken cancellationToken);

        Task<Patient?> GetByIdAsync(int patientId, CancellationToken cancellationToken);

        Task<bool> DeleteAsync(int patientId, CancellationToken cancellationToken);
    }
}
