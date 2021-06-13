using Nahhas.Business.Entities.Base;
using Nahhas.Business.Filters.Interfaces;
using Nahhas.Business.Services.Http.Interfaces;
using Nahhas.Business.Services.Nahhas.Interfaces;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Nahhas.Business.Services.Nahhas
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

        public async Task<IEnumerable<T>> Get()
        {
            using var response = await _service.Client.GetAsync(_requestUri);
            return await response.Content.ReadAsAsync<IEnumerable<T>>();
        }

        public async Task<IEnumerable<T>> Get(IFilter<T> filter)
        {
            using var response = await _service.Client.GetAsync($"{_requestUri}/search{filter}");
            return await response.Content.ReadAsAsync<IEnumerable<T>>();
        }

        public async Task<T> Get(object id)
        {
            using var response = await _service.Client.GetAsync($"{_requestUri}/{id}");
            return await response.Content.ReadAsAsync<T>();
        }

        public async Task<T> Add(T entity)
        {
            var content = new StringContent(JsonConvert.SerializeObject(entity), Encoding.UTF8, "application/json");

            using var response = await _service.Client.PostAsync(_requestUri, content);
            return await response.Content.ReadAsAsync<T>();
        }

        public async Task<T> Update(T entity)
        {
            var content = new StringContent(JsonConvert.SerializeObject(entity), Encoding.UTF8, "application/json");

            using var response = await _service.Client.PutAsync(_requestUri, content);
            return await response.Content.ReadAsAsync<T>();
        }

        public async Task<T> Delete(object id)
        {
            using var response = await _service.Client.DeleteAsync($"{_requestUri}/{id}");
            return await response.Content.ReadAsAsync<T>();
        }

        public async Task<decimal> Count(IFilter<T> filter = null)
        {
            using var response = await _service.Client.GetAsync($"{_requestUri}/count{filter}");
            return await response.Content.ReadAsAsync<decimal>();
        }
    }
}