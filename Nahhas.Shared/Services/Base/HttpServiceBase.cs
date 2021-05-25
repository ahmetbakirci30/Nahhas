using Nahhas.Shared.Services.Interfaces;
using System.Net.Http;

namespace Nahhas.Shared.Services.Base
{
    public class HttpServiceBase<T> : IHttpService<T> where T : class
    {
        private static HttpClient _client;
        private static readonly string baseUrl = "https://localhost:44308/api/";

        public HttpClient Client => _client ??= new HttpClient();

        public string Path
        {
            get
            {
                string name = typeof(T).Name;

                name = name.EndsWith('y') ? $"{name[0..^1]}ie" : name;

                return $"{baseUrl}{name}s/";
            }
        }
    }
}