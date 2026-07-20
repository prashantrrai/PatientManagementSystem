using PatientManagement.Domain.Enums;

namespace PatientManagement.Application.Features.Patients.DTOs
{
    public class PatientDto
    {
        public int PatientId { get; set; }

        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public string FullName => $"{FirstName} {LastName}";

        public Gender Gender { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string MobileNumber { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string Address { get; set; } = string.Empty;

        public string BloodGroup { get; set; } = string.Empty;

        public bool IsActive { get; set; }
    }
}
