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
        public virtual async Task<ActionResult<IEnumerable<TEntity>>> Get()
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
        public virtual async Task<ActionResult<IEnumerable<TEntity>>> Get([FromQuery] Filter filter)
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
        public virtual async Task<ActionResult<TEntity>> Get([FromRoute] Guid id)
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
        public virtual async Task<ActionResult<decimal>> Count([FromQuery] Filter filter)
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
        public virtual async Task<ActionResult<TEntity>> Post([FromBody] TEntity entity)
        {
            try
            {
                var added = await _repository.AddAsync(entity);

                return CreatedAtAction(nameof(Get), new { id = added.Id }, added);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "An error occurred while adding data!");
            }
        }

        [HttpPut]
        public virtual async Task<ActionResult<TEntity>> Put([FromBody] TEntity entity)
        {
            try
            {
                return entity.Id.Equals(Guid.Empty) ?
                    BadRequest("The Id field is required for the update process!") :
                    Ok(await _repository.UpdateAsync(entity));
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
        public virtual async Task<ActionResult<TEntity>> Delete([FromRoute] Guid id)
        {
            try
            {
                return id.Equals(Guid.Empty) ?
                   BadRequest("The Id field is required for the delete process!") :
                   Ok(await _repository.DeleteAsync(id));
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