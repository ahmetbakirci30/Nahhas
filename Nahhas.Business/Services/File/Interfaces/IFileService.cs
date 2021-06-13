using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Nahhas.Business.Services.File.Interfaces
{
    public interface IFileService
    {
        public Task<byte[]> Download(string path);
        public Task<string> Upload(IFormFile file);
        public Task<string> Update(IFormFile file, string path);
        public Task<string> Delete(string path);
    }
}