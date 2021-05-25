using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nahhas.Shared.Entities.Base;
using Nahhas.Shared.Filters.Interfaces;
using Nahhas.Shared.Helpers.Extensions.Repository;
using Nahhas.Shared.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Nahhas.API.Controllers.Base
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class ControllerBase<T, Filter> : ControllerBase
        where T : EntityBase, new()
        where Filter : IFilter<T>, new()
    {
        private readonly IRepository<T> _repository;

        public ControllerBase(IRepository<T> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public virtual async Task<ActionResult<IEnumerable<T>>> Get()
        {
            try
            {
                return Ok(await _repository.Get());
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "An error occurred while fetching data!");
            }
        }

        [HttpGet("search")]
        public virtual async Task<ActionResult<IEnumerable<T>>> Get([FromQuery] Filter filter)
        {
            try
            {
                return Ok(await _repository.Get(filter));
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "An error occurred while fetching data!");
            }
        }

        [HttpGet("{id:Guid}")]
        public virtual async Task<ActionResult<T>> Get([FromRoute] Guid id)
        {
            try
            {
                var entity = await _repository.Get(id);

                return (entity == null) ?
                    NotFound($"{typeof(T).Name} with Id = {id} not found!") : Ok(entity);
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
                return Ok(await _repository.Count(filter));
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "An error occurred while fetching data!");
            }
        }

        [HttpPost]
        public virtual async Task<ActionResult<T>> Post([FromBody] T entity)
        {
            try
            {
                var added = await _repository.Add(entity);

                return CreatedAtAction(nameof(Get), new { id = added.Id }, added);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "An error occurred while adding data!");
            }
        }

        [HttpPut]
        public virtual async Task<ActionResult<T>> Put([FromBody] T entity)
        {
            try
            {
                return (entity.Id == Guid.Empty) ?
                    BadRequest("The Id field is required.") :
                    Ok(await _repository.Update(entity));
            }
            catch
            {
                return (!await _repository.Exists(entity.Id)) ?
                    NotFound($"{typeof(T).Name} with Id = {entity.Id} not found!") :
                    StatusCode(StatusCodes.Status500InternalServerError,
                    "An error occurred while updating data!");
            }
        }

        [HttpDelete("{id:Guid}")]
        public virtual async Task<ActionResult<T>> Delete([FromRoute] Guid id)
        {
            try
            {
                return Ok(await _repository.Delete(id));
            }
            catch
            {
                return (!await _repository.Exists(id)) ?
                   NotFound($"{typeof(T).Name} with Id = {id} not found!") :
                   StatusCode(StatusCodes.Status500InternalServerError,
                   "An error occurred while deleting data!");
            }
        }
    }
}