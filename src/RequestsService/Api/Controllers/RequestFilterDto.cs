using System;

namespace RequestsService.Api.Controllers
{
    public class RequestFilterDto
    {
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string? EmployeeName { get; set; }
    }
}