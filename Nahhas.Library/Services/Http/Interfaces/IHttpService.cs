using System.Net.Http;

namespace Nahhas.Library.Services.Http.Interfaces
{
    public interface IHttpService
    {
        HttpClient Client { get; }
    }
}