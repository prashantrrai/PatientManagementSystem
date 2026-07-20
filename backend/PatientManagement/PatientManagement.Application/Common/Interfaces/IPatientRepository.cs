using PatientManagement.Application.Common.Models;
using PatientManagement.Application.Features.Patients.DTOs;
using PatientManagement.Domain.Entities;

namespace PatientManagement.Application.Common.Interfaces
{
    public interface IPatientRepository
    {
        Task<int> UpsertAsync(Patient patient, CancellationToken cancellationToken);

        Task<PagedResponse<PatientDto>> GetAllAsync(
            string? search,
            int pageNumber,
            int pageSize,
            CancellationToken cancellationToken);

        Task<PatientDto?> GetByIdAsync(int patientId, CancellationToken cancellationToken);

        Task<bool> DeleteAsync(int patientId, CancellationToken cancellationToken);
    }
}
