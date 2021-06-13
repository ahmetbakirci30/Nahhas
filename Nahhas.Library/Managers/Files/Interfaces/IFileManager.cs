using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Nahhas.Library.Managers.Files.Interfaces
{
    public interface IFileManager
    {
        Task<byte[]> DownloadAsync(string path);
        Task<string> UploadAsync(IFormFile file);
        Task<string> UpdateAsync(IFormFile file, string path);
        Task<string> DeleteAsync(string path);
    }
}