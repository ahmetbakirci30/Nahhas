using Nahhas.Shared.Entities.Base;
using Nahhas.Shared.Filters.Interfaces;
using Nahhas.Shared.Repositories.Interfaces;
using Nahhas.Shared.Services.Interfaces;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Nahhas.Shared.Repositories
{
    public class StatusesRepository<T> : IRepository<T> where T : EntityBase, new()
    {
        private readonly IHttpService<T> _service;

        public StatusesRepository(IHttpService<T> service)
        {
            _service = service;
        }

        public async Task<IEnumerable<T>> Get()
        {
            using var response = await _service.Client.GetAsync(_service.Path);
            return await response.Content.ReadAsAsync<IEnumerable<T>>();
        }

        public async Task<IEnumerable<T>> Get(IFilter<T> filter)
        {
            using var response = await _service.Client.GetAsync($"{_service.Path}search{filter}");
            return await response.Content.ReadAsAsync<IEnumerable<T>>();
        }

        public async Task<T> Get(object id)
        {
            using var response = await _service.Client.GetAsync(_service.Path + id);
            return await response.Content.ReadAsAsync<T>();
        }

        public async Task<T> Add(T entity)
        {
            var content = new StringContent(JsonConvert.SerializeObject(entity), Encoding.UTF8, "application/json");

            using var response = await _service.Client.PostAsync(_service.Path, content);
            return await response.Content.ReadAsAsync<T>();
        }

        public async Task<T> Update(T entity)
        {
            var content = new StringContent(JsonConvert.SerializeObject(entity), Encoding.UTF8, "application/json");

            using var response = await _service.Client.PutAsync(_service.Path, content);
            return await response.Content.ReadAsAsync<T>();
        }

        public async Task<T> Delete(object id)
        {
            using var response = await _service.Client.DeleteAsync(_service.Path + id);
            return await response.Content.ReadAsAsync<T>();
        }

        public async Task<decimal> Count(IFilter<T> filter = null)
        {
            using var response = await _service.Client.GetAsync($"{_service.Path}count{filter}");
            return await response.Content.ReadAsAsync<decimal>();
        }
    }
}