using MediatR;
using PatientManagement.Application.Common.Interfaces;

namespace PatientManagement.Application.Features.Patients.Commands.DeletePatient
{
    public class DeletePatientCommandHandler : IRequestHandler<DeletePatientCommand, bool>
    {
        private readonly IPatientRepository _repository;

        public DeletePatientCommandHandler(IPatientRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(DeletePatientCommand request, CancellationToken cancellationToken)
        {
            return await _repository.DeleteAsync(request.PatientId, cancellationToken);
        }
    }
}
