using MediatR;
using PatientManagement.Application.Common.Interfaces;
using PatientManagement.Application.Common.Models;
using PatientManagement.Application.Features.Patients.DTOs;

namespace PatientManagement.Application.Features.Patients.Queries.GetPatients
{
    public class GetPatientsQueryHandler : IRequestHandler<GetPatientsQuery, PagedResponse<PatientDto>>
    {
        private readonly IPatientRepository _repository;

        public GetPatientsQueryHandler(IPatientRepository repository)
        {
            _repository = repository;
        }

        public async Task<PagedResponse<PatientDto>> Handle(GetPatientsQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetAllAsync(
                request.Search,
                request.PageNumber,
                request.PageSize,
                cancellationToken);
        }
    }
}
