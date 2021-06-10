using Microsoft.AspNetCore.Http;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Nahhas.Shared.Repositories
{
    public class FileRepository
    {
        private readonly HttpClient http;
        private readonly string url;

        public FileRepository()
        {
            http = new HttpClient();
            url = "https://localhost:44308/api/files";
        }

        public async Task<byte[]> Get(string path)
        {
            http.DefaultRequestHeaders.Add("path", path);
            return await http.GetByteArrayAsync(url);
        }

        public async Task<string> Add(IFormFile file)
        {
            using var response = await http.PostAsync(url, CofigureFileToSend(file));
            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> Update(IFormFile file, string path)
        {
            http.DefaultRequestHeaders.Add("path", path);
            using var response = await http.PutAsync(url, CofigureFileToSend(file));
            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> Delete(string path)
        {
            http.DefaultRequestHeaders.Add("path", path);
            using var response = await http.DeleteAsync(url);
            return await response.Content.ReadAsStringAsync();
        }

        private static MultipartFormDataContent CofigureFileToSend(IFormFile file) => new()
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