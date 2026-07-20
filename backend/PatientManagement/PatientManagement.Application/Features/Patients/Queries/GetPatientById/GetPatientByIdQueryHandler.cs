using MediatR;
using PatientManagement.Application.Common.Interfaces;
using PatientManagement.Application.Features.Patients.DTOs;

namespace PatientManagement.Application.Features.Patients.Queries.GetPatientById
{
    public class GetPatientByIdQueryHandler : IRequestHandler<GetPatientByIdQuery, PatientDto?>
    {
        private readonly IPatientRepository _repository;

        public GetPatientByIdQueryHandler(IPatientRepository repository)
        {
            _repository = repository;
        }

        public async Task<PatientDto?> Handle(GetPatientByIdQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetByIdAsync(request.PatientId, cancellationToken);
        }
    }
}
