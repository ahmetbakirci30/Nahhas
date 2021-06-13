using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nahhas.Library.Entities.Interfaces;
using Nahhas.Library.Filters.Entity.Interfaces;
using Nahhas.Library.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Nahhas.API.Controllers.Base
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class ControllerBase<TEntity, Filter> : ControllerBase
        where TEntity : IEntity, new()
        where Filter : IFilter<TEntity>, new()
    {
        private readonly IGenericRepository<TEntity> _repository;

        public ControllerBase(IGenericRepository<TEntity> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public virtual async Task<ActionResult<IEnumerable<TEntity>>> GetAsync()
        {
            try
            {
                return Ok(await _repository.GetAsync());
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "An error occurred while fetching data!");
            }
        }

        [HttpGet("search")]
        public virtual async Task<ActionResult<IEnumerable<TEntity>>> GetAsync([FromQuery] Filter filter)
        {
            try
            {
                return Ok(await _repository.GetAsync(filter));
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "An error occurred while fetching data!");
            }
        }

        [HttpGet("{id:Guid}")]
        public virtual async Task<ActionResult<TEntity>> GetAsync([FromRoute] Guid id)
        {
            try
            {
                var entity = await _repository.GetAsync(id);

                return (entity == null) ?
                    NotFound($"{typeof(TEntity).Name} with Id = {id} not found!") : Ok(entity);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "An error occurred while fetching data!");
            }
        }

        [HttpGet("count")]
        public virtual async Task<ActionResult<decimal>> CountAsync([FromQuery] Filter filter)
        {
            try
            {
                return Ok(await _repository.CountAsync(filter));
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "An error occurred while fetching data!");
            }
        }

        [HttpPost]
        public virtual async Task<ActionResult<TEntity>> PostAsync([FromBody] TEntity entity)
        {
            try
            {
                var added = await _repository.AddAsync(entity);

                return CreatedAtAction(nameof(GetAsync), new { id = added.Id }, added);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "An error occurred while adding data!");
            }
        }

        [HttpPut]
        public virtual async Task<ActionResult<TEntity>> PutAsync([FromBody] TEntity entity)
        {
            try
            {
                return Ok(await _repository.UpdateAsync(entity));
            }
            catch
            {
                return (!await _repository.ExistsAsync(entity.Id)) ?
                     NotFound($"{typeof(TEntity).Name} with Id = {entity.Id} not found!") :
                     StatusCode(StatusCodes.Status500InternalServerError,
                     "An error occurred while updating data!");
            }
        }

        [HttpDelete("{id:Guid}")]
        public virtual async Task<ActionResult<TEntity>> DeleteAsync([FromRoute] Guid id)
        {
            try
            {
                return Ok(await _repository.DeleteAsync(id));
            }
            catch
            {
                return (!await _repository.ExistsAsync(id)) ?
                   NotFound($"{typeof(TEntity).Name} with Id = {id} not found!") :
                   StatusCode(StatusCodes.Status500InternalServerError,
                   "An error occurred while deleting data!");
            }
        }
    }
}