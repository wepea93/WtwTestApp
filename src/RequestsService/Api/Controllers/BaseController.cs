using Microsoft.AspNetCore.Mvc;
using RequestsService.Infrastructure;
using RequestsService.Core;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RequestsService.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class BaseController<T> : ControllerBase, IController<T> where T : class, IEntity
    {
        protected readonly IRepository<T> _repository;

        public BaseController(IRepository<T> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async virtual Task<ActionResult<IEnumerable<T>>> GetAll()
        {
            var entities = await _repository.GetAllAsync();
            return Ok(entities);
        }

        [HttpGet("{id}")]
        public async virtual Task<ActionResult<T>> GetById(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null) return NotFound();
            return Ok(entity);
        }

        [HttpPost]
        public async virtual Task<ActionResult<T>> Create(T entity)
        {
            await _repository.AddAsync(entity);
            return CreatedAtAction(nameof(GetById), new { id = entity.Id }, entity);
        }

        [HttpPut("{id}")]
        public async virtual Task<IActionResult> Update(int id, T entity)
        {
            if (id != entity.Id) return BadRequest();
            await _repository.UpdateAsync(entity);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async virtual Task<IActionResult> Delete(int id)
        {
            await _repository.DeleteAsync(id);
            return NoContent();
        }
    }
}