using Microsoft.AspNetCore.Http;
using Nahhas.Shared.Filters.Interfaces;
using Nahhas.Shared.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Nahhas.Shared.Repositories
{
    public class FileRepository
    {
        private static readonly HttpClient http = new();
        private static readonly string url = "https://localhost:44308/api/files";

        public async Task<byte[]> Get(string path)
        {
            return await http.GetByteArrayAsync(url);
        }

        public async Task<string> Add(IFormFile file)
        {
            using var content = new MultipartFormDataContent
            {
                {
                    new StreamContent(file.OpenReadStream())
                    {
                        Headers =
                        {
                            ContentLength = file.Length,
                            ContentType = new MediaTypeHeaderValue(file.ContentType)
                        }
                    }, "File", file.FileName
                }
            };

            using var response = await http.PostAsync(url, content);
            return await response.Content.ReadAsStringAsync();
        }

        public Task<IFormFile> Update(IFormFile entity, string path)
        {
            throw new NotImplementedException();
        }

        public Task<IFormFile> Delete(string path)
        {
            throw new NotImplementedException();
        }
    }
}