using MediatR;
using PatientManagement.Domain.Entities;

namespace PatientManagement.Application.Features.Patients.Queries.GetPatientById
{
    public class GetPatientByIdQuery : IRequest<Patient?>
    {
        public int PatientId { get; set; }
    }
}
