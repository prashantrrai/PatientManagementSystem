using MediatR;

namespace PatientManagement.Application.Features.Patients.Commands.DeletePatient
{
    public class DeletePatientCommand : IRequest<bool>
    {
        public int PatientId { get; set; }
    }
}
