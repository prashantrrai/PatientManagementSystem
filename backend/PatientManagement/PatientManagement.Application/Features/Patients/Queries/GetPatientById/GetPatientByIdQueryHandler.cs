using MediatR;
using PatientManagement.Application.Common.Interfaces;
using PatientManagement.Domain.Entities;

namespace PatientManagement.Application.Features.Patients.Queries.GetPatientById
{
    public class GetPatientByIdQueryHandler : IRequestHandler<GetPatientByIdQuery, Patient?>
    {
        private readonly IPatientRepository _repository;

        public GetPatientByIdQueryHandler(IPatientRepository repository)
        {
            _repository = repository;
        }

        public async Task<Patient?> Handle(GetPatientByIdQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetByIdAsync(request.PatientId, cancellationToken);
        }
    }
}
