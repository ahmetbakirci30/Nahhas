using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Nahhas.Shared.Managers.Files.Interfaces
{
    public interface IFileManager
    {
        Task<byte[]> Download(string path);
        Task<string> Upload(IFormFile file);
        Task<string> Update(IFormFile file, string path);
        Task<string> Delete(string path);
    }
}