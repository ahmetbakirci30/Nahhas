using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Nahhas.Business.Services.File.Interfaces
{
    public interface IFileService
    {
        public Task<byte[]> Get(string path);
        public Task<string> Add(IFormFile file);
        public Task<string> Update(IFormFile file, string path);
        public Task<string> Delete(string path);
    }
}