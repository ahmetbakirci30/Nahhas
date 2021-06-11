using Nahhas.Business.Services.Interfaces;
using System;
using System.Net.Http;

namespace Nahhas.Business.Services
{
    public class HttpService : IHttpService
    {
        static HttpService()
        {
            _client = new HttpClient
            {
                BaseAddress = new Uri("https://nahhasapi20210611231706.azurewebsites.net/api/")
            };
        }

        private static readonly HttpClient _client;

        public HttpClient Client => _client;
    }
}