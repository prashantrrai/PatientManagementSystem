using FluentValidation;

namespace PatientManagement.Application.Features.Patients.Commands.UpsertPatient
{
    public class UpsertPatientCommandValidator : AbstractValidator<UpsertPatientCommand>
    {
        public UpsertPatientCommandValidator()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty()
                .MaximumLength(100);

            RuleFor(x => x.LastName)
                .NotEmpty()
                .MaximumLength(100);

            RuleFor(x => x.MobileNumber)
                .NotEmpty()
                .Matches(@"^[6-9]\d{9}$")
                .WithMessage("Invalid mobile number.");

            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress();

            RuleFor(x => x.Address)
                .NotEmpty()
                .MaximumLength(500);

            RuleFor(x => x.BloodGroup)
                .NotEmpty();

            RuleFor(x => x.DateOfBirth)
                .LessThan(DateTime.Today)
                .WithMessage("Date of birth must be in the past.");

            RuleFor(x => x.Gender)
                .IsInEnum();
        }
    }
}
