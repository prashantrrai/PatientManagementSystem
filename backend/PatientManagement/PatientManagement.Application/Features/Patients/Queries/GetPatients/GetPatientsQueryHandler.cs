using MediatR;
using PatientManagement.Application.Common.Interfaces;
using PatientManagement.Domain.Entities;

namespace PatientManagement.Application.Features.Patients.Queries.GetPatients
{
    public class GetPatientsQueryHandler : IRequestHandler<GetPatientsQuery, IEnumerable<Patient>>
    {
        private readonly IPatientRepository _repository;

        public GetPatientsQueryHandler(IPatientRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Patient>> Handle(GetPatientsQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetAllAsync(
                request.Search,
                request.PageNumber,
                request.PageSize,
                cancellationToken);
        }
    }
}
