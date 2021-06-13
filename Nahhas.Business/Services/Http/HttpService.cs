using Nahhas.Business.Services.Http.Interfaces;
using System;
using System.Net.Http;

namespace Nahhas.Business.Services.Http
{
    public class HttpService : IHttpService
    {
        private static readonly HttpClient _client;

        static HttpService()
        {
            _client = new HttpClient
            {
                BaseAddress = new Uri("https://nahhasapi20210611231706.azurewebsites.net/api/")
            };
        }

        public HttpClient Client => _client;
    }
}