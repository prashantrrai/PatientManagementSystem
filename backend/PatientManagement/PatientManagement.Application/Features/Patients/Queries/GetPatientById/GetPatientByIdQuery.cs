using MediatR;
using PatientManagement.Application.Features.Patients.DTOs;

namespace PatientManagement.Application.Features.Patients.Queries.GetPatientById
{
    public class GetPatientByIdQuery : IRequest<PatientDto?>
    {
        public int PatientId { get; set; }
    }
}
