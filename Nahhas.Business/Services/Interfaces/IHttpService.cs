using System.Net.Http;

namespace Nahhas.Business.Services.Interfaces
{
    public interface IHttpService
    {
        HttpClient Client { get; }
    }
}