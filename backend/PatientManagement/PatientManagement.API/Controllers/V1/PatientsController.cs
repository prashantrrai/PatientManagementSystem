using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using PatientManagement.Application.Features.Patients.Commands.DeletePatient;
using PatientManagement.Application.Features.Patients.Commands.UpsertPatient;
using PatientManagement.Application.Features.Patients.Queries.GetPatientById;
using PatientManagement.Application.Features.Patients.Queries.GetPatients;

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

        [HttpGet]
        public async Task<IActionResult> GetAll(
            [FromQuery] string? search,
            [FromQuery] int pageNumber = 1,
            [FromQuery] int pageSize = 10,
            CancellationToken cancellationToken = default)
        {
            var patients = await _mediator.Send(new GetPatientsQuery
            {
                Search = search,
                PageNumber = pageNumber,
                PageSize = pageSize
            }, cancellationToken);

            return Ok(patients);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id, CancellationToken cancellationToken)
        {
            var patient = await _mediator.Send(
                new GetPatientByIdQuery
                {
                    PatientId = id
                },
                cancellationToken);

            if (patient == null)
            {
                return NotFound();
            }

            return Ok(patient);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
        {
            bool deleted = await _mediator.Send(
                new DeletePatientCommand
                {
                    PatientId = id
                },
                cancellationToken);

            if (!deleted)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
