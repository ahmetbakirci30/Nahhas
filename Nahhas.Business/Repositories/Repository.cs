using Nahhas.Business.Filters.Interfaces;
using Nahhas.Business.Repositories.Interfaces;
using Nahhas.Business.Services.Interfaces;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Nahhas.Business.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly IHttpService _service;
        private readonly string _path;

        public Repository(IHttpService service, string path)
        {
            _service = service;
            _path = path;
        }

        public async Task<IEnumerable<T>> Get()
        {
            using var response = await _service.Client.GetAsync(_path);
            return await response.Content.ReadAsAsync<IEnumerable<T>>();
        }

        public async Task<IEnumerable<T>> Get(IFilter<T> filter)
        {
            using var response = await _service.Client.GetAsync($"{_path}/search{filter}");
            return await response.Content.ReadAsAsync<IEnumerable<T>>();
        }

        public async Task<T> Get(object id)
        {
            using var response = await _service.Client.GetAsync($"{_path}/{id}");
            return await response.Content.ReadAsAsync<T>();
        }

        public async Task<T> Add(T entity)
        {
            var content = new StringContent(JsonConvert.SerializeObject(entity), Encoding.UTF8, "application/json");

            using var response = await _service.Client.PostAsync(_path, content);
            return await response.Content.ReadAsAsync<T>();
        }

        public async Task<T> Update(T entity)
        {
            var content = new StringContent(JsonConvert.SerializeObject(entity), Encoding.UTF8, "application/json");

            using var response = await _service.Client.PutAsync(_path, content);
            return await response.Content.ReadAsAsync<T>();
        }

        public async Task<T> Delete(object id)
        {
            using var response = await _service.Client.DeleteAsync($"{_path}/{id}");
            return await response.Content.ReadAsAsync<T>();
        }

        public async Task<decimal> Count(IFilter<T> filter = null)
        {
            using var response = await _service.Client.GetAsync($"{_path}/count{filter}");
            return await response.Content.ReadAsAsync<decimal>();
        }
    }
}