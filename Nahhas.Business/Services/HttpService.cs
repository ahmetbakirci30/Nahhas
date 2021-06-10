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
                BaseAddress = new Uri("https://localhost:44308/api/")
            };
        }

        private static readonly HttpClient _client;

        public HttpClient Client => _client;
    }
}