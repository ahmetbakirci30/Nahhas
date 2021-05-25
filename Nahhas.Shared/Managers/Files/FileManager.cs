using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Nahhas.Shared.Helpers.Extensions.FormFile;
using Nahhas.Shared.Managers.Files.Interfaces;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Nahhas.Shared.Managers.Files
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

        public async Task<byte[]> Download(string name)
        {
            string img = Path.Combine(_imagesFolder, name);
            string vid = Path.Combine(_videosFolder, name);

            if (File.Exists(img))
                return await File.ReadAllBytesAsync(img);

            else if (File.Exists(vid))
                return await File.ReadAllBytesAsync(vid);

            return null;
        }

        public async Task<string> Upload(IFormFile file)
        {
            var storagePath = file.IsImage() ? _imagesFolder : _videosFolder;

            if (!Directory.Exists(storagePath))
                Directory.CreateDirectory(storagePath);

            var fileName = GenerateRandomName(file.FileName);
            var fullPath = Path.Combine(storagePath, fileName);
            using var stream = new FileStream(fullPath, FileMode.Create);
            await file.CopyToAsync(stream);

            return fileName;
        }

        public async Task<string> Update(IFormFile file, string name)
            => string.IsNullOrWhiteSpace(await Delete(name)) ? string.Empty : await Upload(file);

        public async Task<string> Delete(string name)
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

        private static string GenerateRandomName(string name)
        {
            DateTime _currentDateTime = DateTime.Now;

            return string.Join("-", Guid.NewGuid().ToString(),
                                    _currentDateTime.Year,
                                    _currentDateTime.Month,
                                    _currentDateTime.Day,
                                    _currentDateTime.Hour,
                                    _currentDateTime.Minute,
                                    _currentDateTime.Second,
                                    _currentDateTime.Millisecond,
                                    name);
        }
    }
}