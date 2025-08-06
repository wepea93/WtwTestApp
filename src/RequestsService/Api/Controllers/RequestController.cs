using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using RequestsService.Core;
using RequestsService.Infrastructure;

namespace RequestsService.Api.Controllers
{
    [Authorize]
    public class RequestController : BaseController<Request>
    {
        public RequestController(RequestRepository repository) : base(repository)
        {

        }

        [HttpPost("filter")]
        public async Task<ActionResult<IEnumerable<Request>>> GetFiltered([FromBody] RequestFilterDto filter)
        {
            var entities = await ((RequestRepository)_repository).GetFilteredAsync(x =>
                (filter.StartDate == null || x.StartDate >= filter.StartDate) &&
                (filter.EndDate == null || x.EndDate <= filter.EndDate) &&
                (string.IsNullOrEmpty(filter.EmployeeName) || x.EmployeeName.Contains(filter.EmployeeName))
            );
            return Ok(entities);
        }
    }
}