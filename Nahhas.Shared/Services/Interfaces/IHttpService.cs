using System.Net.Http;

namespace Nahhas.Shared.Services.Interfaces
{
    public interface IHttpService<T> where T : class
    {
        HttpClient Client { get; }
        string Path { get; }
    }
}