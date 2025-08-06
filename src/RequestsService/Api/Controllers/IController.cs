using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RequestsService.Api.Controllers
{
    public interface IController<T> where T : class
    {
        Task<ActionResult<T>> GetById(int id);
        Task<ActionResult<IEnumerable<T>>> GetAll();
        Task<ActionResult<T>> Create(T entity);
        Task<IActionResult> Update(int id, T entity);
        Task<IActionResult> Delete(int id);
    }
}