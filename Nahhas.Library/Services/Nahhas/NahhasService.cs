using Nahhas.Library.Entities.Base;
using Nahhas.Library.Filters.Entity.Interfaces;
using Nahhas.Library.Services.Http.Interfaces;
using Nahhas.Library.Services.Nahhas.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Nahhas.Library.Services.Nahhas
{
    public class NahhasService<T> : INahhasService<T> where T : EntityBase, new()
    {
        private readonly IHttpService _service;
        private readonly string _requestUri;

        public NahhasService(IHttpService service, string requestUri)
        {
            _service = service;
            _requestUri = requestUri;
        }

        public async Task<IEnumerable<T>> GetAsync()
        {
            using var response = await _service.Client.GetAsync(_requestUri);
            return await response.Content.ReadAsAsync<IEnumerable<T>>();
        }

        public async Task<IEnumerable<T>> GetAsync(IFilter<T> filter)
        {
            using var response = await _service.Client.GetAsync($"{_requestUri}/search{filter}");
            return await response.Content.ReadAsAsync<IEnumerable<T>>();
        }

        public async Task<T> GetAsync(Guid id)
        {
            using var response = await _service.Client.GetAsync($"{_requestUri}/{id}");
            return await response.Content.ReadAsAsync<T>();
        }

        public async Task<T> AddAsync(T entity)
        {
            var content = new StringContent(JsonConvert.SerializeObject(entity), Encoding.UTF8, "application/json");

            using var response = await _service.Client.PostAsync(_requestUri, content);
            return await response.Content.ReadAsAsync<T>();
        }

        public async Task<T> UpdateAsync(T entity)
        {
            var content = new StringContent(JsonConvert.SerializeObject(entity), Encoding.UTF8, "application/json");

            using var response = await _service.Client.PutAsync(_requestUri, content);
            return await response.Content.ReadAsAsync<T>();
        }

        public async Task<T> DeleteAsync(Guid id)
        {
            using var response = await _service.Client.DeleteAsync($"{_requestUri}/{id}");
            return await response.Content.ReadAsAsync<T>();
        }

        public async Task<decimal> CountAsync(IFilter<T> filter = null)
        {
            using var response = await _service.Client.GetAsync($"{_requestUri}/count{filter}");
            return await response.Content.ReadAsAsync<decimal>();
        }
    }
}