using MediatR;
using PatientManagement.Domain.Entities;

namespace PatientManagement.Application.Features.Patients.Queries.GetPatients
{
    public class GetPatientsQuery : IRequest<IEnumerable<Patient>>
    {
        public string? Search { get; set; }

        public int PageNumber { get; set; } = 1;

        public int PageSize { get; set; } = 10;
    }
}
