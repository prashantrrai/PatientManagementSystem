using MediatR;
using PatientManagement.Application.Common.Interfaces;
using PatientManagement.Domain.Entities;

namespace PatientManagement.Application.Features.Patients.Commands.UpsertPatient
{
    public class UpsertPatientCommandHandler : IRequestHandler<UpsertPatientCommand, int>
    {
        private readonly IPatientRepository _repository;

        public UpsertPatientCommandHandler(IPatientRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> Handle(UpsertPatientCommand request, CancellationToken cancellationToken)
        {
            var patient = new Patient
            {
                PatientId = request.PatientId,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Gender = request.Gender,
                DateOfBirth = request.DateOfBirth,
                MobileNumber = request.MobileNumber,
                Email = request.Email,
                Address = request.Address,
                BloodGroup = request.BloodGroup
            };

            return await _repository.UpsertAsync(patient, cancellationToken);
        }
    }
}
