using MediatR;
using PatientManagement.Application.Common.Models;
using PatientManagement.Application.Features.Patients.DTOs;

namespace PatientManagement.Application.Features.Patients.Queries.GetPatients
{
    public class GetPatientsQuery : IRequest<PagedResponse<PatientDto>>
    {
        public string? Search { get; set; }

        public int PageNumber { get; set; } = 1;

        public int PageSize { get; set; } = 10;
    }
}
