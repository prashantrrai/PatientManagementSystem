using MediatR;
using PatientManagement.Domain.Enums;

namespace PatientManagement.Application.Features.Patients.Commands.UpsertPatient
{
    public class UpsertPatientCommand : IRequest<int>
    {
        public int PatientId { get; set; }

        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public Gender Gender { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string MobileNumber { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string Address { get; set; } = string.Empty;

        public string BloodGroup { get; set; } = string.Empty;
    }
}
