using Nahhas.Shared.Entities.Base;
using Nahhas.Shared.Services.Interfaces;
using System.Net.Http;

namespace Nahhas.Shared.Services.Base
{
    public class HttpServiceBase<T> : IHttpService<T> where T : EntityBase, new()
    {
        private readonly string _baseUrl;

        public HttpServiceBase()
        {
            _baseUrl = "https://localhost:44308/api/";
        }

        public HttpClient Client => new();

        public string Path
        {
            get
            {
                string name = typeof(T).Name;

                name = name.EndsWith('y') ? $"{name[0..^1]}ie" : name;

                return $"{_baseUrl}{name}s/";
            }
        }
    }
}