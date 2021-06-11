using Microsoft.AspNetCore.Http;
using Nahhas.Business.Services.Interfaces;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Nahhas.Business.Repositories
{
    public class FileRepository
    {
        private readonly IHttpService _service;
        private readonly string _path;

        public FileRepository(IHttpService service, string path)
        {
            _service = service;
            _path = path;
        }

        public async Task<byte[]> Get(string path)
        {
            _service.Client.DefaultRequestHeaders.Add("path", path);
            return await _service.Client.GetByteArrayAsync(_path);
        }

        public async Task<string> Add(IFormFile file)
        {
            using var response = await _service.Client.PostAsync(_path, CofigureFileToSend(file));
            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> Update(IFormFile file, string path)
        {
            _service.Client.DefaultRequestHeaders.Add("path", path);
            using var response = await _service.Client.PutAsync(_path, CofigureFileToSend(file));
            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> Delete(string path)
        {
            _service.Client.DefaultRequestHeaders.Add("path", path);
            using var response = await _service.Client.DeleteAsync(_path);
            return await response.Content.ReadAsStringAsync();
        }

        private static MultipartFormDataContent CofigureFileToSend(IFormFile file)
            => new MultipartFormDataContent()
            {
                {
                    new StreamContent(file.OpenReadStream())
                    {
                        Headers =
                        {
                            ContentLength = file.Length,
                            ContentType = new MediaTypeHeaderValue(file.ContentType)
                        }
                    },
                    "File",
                    file.FileName
                }
            };
    }
}