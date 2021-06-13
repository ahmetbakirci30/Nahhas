using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Nahhas.Library.Extensions.Files;
using Nahhas.Library.Managers.Files.Interfaces;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Nahhas.Library.Managers.Files
{
    public class FileManager : IFileManager
    {
        private readonly string _webRootPath;
        private readonly string _statusesFolder;
        private readonly string _imagesFolder;
        private readonly string _videosFolder;

        public FileManager(IHostingEnvironment hostEnvironment)
        {
            _webRootPath = hostEnvironment.WebRootPath;
            _statusesFolder = Path.Combine(_webRootPath, "statuses");
            _imagesFolder = Path.Combine(_statusesFolder, "images");
            _videosFolder = Path.Combine(_statusesFolder, "videos");
        }

        public async Task<byte[]> DownloadAsync(string name)
        {
            string img = Path.Combine(_imagesFolder, name);
            string vid = Path.Combine(_videosFolder, name);

            if (File.Exists(img))
                return await File.ReadAllBytesAsync(img);

            else if (File.Exists(vid))
                return await File.ReadAllBytesAsync(vid);

            return null;
        }

        public async Task<string> UploadAsync(IFormFile file)
        {
            var storagePath = file.IsImage() ? _imagesFolder : _videosFolder;

            if (!Directory.Exists(storagePath))
                Directory.CreateDirectory(storagePath);

            var fileName = GenerateUniqueName(file.FileName);
            var fullPath = Path.Combine(storagePath, fileName);
            using var stream = new FileStream(fullPath, FileMode.Create);
            await file.CopyToAsync(stream);

            return fileName;
        }

        public async Task<string> UpdateAsync(IFormFile file, string name)
        {
            await DeleteAsync(name);
            return await UploadAsync(file);
        }

        public async Task<string> DeleteAsync(string name)
        {
            string img = Path.Combine(_imagesFolder, name);
            string vid = Path.Combine(_videosFolder, name);

            if (File.Exists(img))
            {
                File.Delete(img);
                return await Task.FromResult(name);
            }
            else if (File.Exists(vid))
            {
                File.Delete(vid);
                return await Task.FromResult(name);
            }

            return await Task.FromResult(string.Empty);
        }

        private static string GenerateUniqueName(string fileName)
        {
            var currentDateTime = DateTime.Now;
            var uniqueName = Guid.NewGuid().ToString("N") + Path.GetExtension(fileName);

            return string.Join("-", currentDateTime.Year,
                                    currentDateTime.Month,
                                    currentDateTime.Day,
                                    currentDateTime.Hour,
                                    currentDateTime.Minute,
                                    currentDateTime.Second,
                                    currentDateTime.Millisecond,
                                    uniqueName);
        }
    }
}