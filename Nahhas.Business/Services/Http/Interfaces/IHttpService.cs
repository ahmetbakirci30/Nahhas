using System.Net.Http;

namespace Nahhas.Business.Services.Http.Interfaces
{
    public interface IHttpService
    {
        HttpClient Client { get; }
    }
}