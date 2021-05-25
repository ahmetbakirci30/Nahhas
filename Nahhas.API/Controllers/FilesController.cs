using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nahhas.Shared.Helpers.Extensions.FormFile;
using Nahhas.Shared.Managers.Files.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Threading.Tasks;

namespace Nahhas.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilesController : ControllerBase
    {
        private readonly IFileManager _fileManager;

        public FilesController(IFileManager fileManager)
        {
            _fileManager = fileManager;
        }

        [HttpGet]
        public async Task<ActionResult> Download([Required][FromHeader] string path)
        {
            try
            {
                var name = Path.GetFileName(path);
                var file = await _fileManager.Download(name);

                return (file != null && file.Length > 0) ?
                    File(file, "application/octet-stream", name) :
                    NotFound($"File named {name} not found!");
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error downloading file!");
            }
        }

        [HttpPost]
        public async Task<ActionResult<string>> Upload([Required][FromForm] IFormFile file)
        {
            try
            {
                if (file.Length > 0)
                {
                    string fullPath =
                        GetUploadedFilePath(file, await _fileManager.Upload(file));

                    return CreatedAtAction(nameof(Download),
                        new { fullPath }, fullPath);
                }

                return BadRequest("File is required!");
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error uploading file!");
            }
        }

        [HttpPut]
        public async Task<ActionResult<string>> Update([Required][FromHeader] string path,
            [Required][FromForm] IFormFile file)
        {
            try
            {
                if (file.Length > 0)
                {
                    var name = Path.GetFileName(path);
                    var updated = await _fileManager.Update(file, name);

                    return string.IsNullOrWhiteSpace(updated) ?
                        NotFound($"File named {name} not found!") :
                        Ok(GetUploadedFilePath(file, updated));
                }

                return BadRequest("File is required!");
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error updating file!");
            }
        }

        [HttpDelete]
        public async Task<ActionResult<string>> Delete([Required][FromHeader] string path)
        {
            try
            {
                var name = Path.GetFileName(path);
                var deleted = await _fileManager.Delete(name);

                return string.IsNullOrWhiteSpace(deleted) ?
                    NotFound($"File named {name} not found!") : Ok(deleted);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error deleting file!");
            }
        }

        private string GetUploadedFilePath(IFormFile file, string fileName)
            => string.Format("{0}://{1}{2}/{3}/{4}/{5}",
                             Request.Scheme,
                             Request.Host,
                             Request.PathBase,
                             "statuses", file.IsImage() ? "images" : "videos",
                             fileName);
    }
}