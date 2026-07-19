using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using PatientManagement.Application.Features.Patients.Commands.UpsertPatient;

namespace PatientManagement.API.Controllers.V1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class PatientsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PatientsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("upsert")]
        public async Task<IActionResult> Upsert(UpsertPatientCommand command, CancellationToken cancellationToken)
        {
            int patientId = await _mediator.Send(command, cancellationToken);

            return Ok(new
            {
                Success = true,
                PatientId = patientId
            });
        }
    }
}
