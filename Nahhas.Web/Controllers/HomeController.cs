using Microsoft.AspNetCore.Mvc;
using Nahhas.Library.Services.Client.Interfaces;
using Nahhas.Web.Models;
using System.Diagnostics;
using System.IO;
using System.Net.Mime;
using System.Threading.Tasks;

namespace Nahhas.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly INahhasServices _nahhas;

        public HomeController(INahhasServices nahhas)
        {
            _nahhas = nahhas;
        }

        public async Task<IActionResult> Index()
            => View(new NahhasStatuses
            {
                Videos = await _nahhas.VideoService.GetAsync(),
                Images = await _nahhas.ImageService.GetAsync(),
                Quotes = await _nahhas.QuoteService.GetAsync(),

                TotalStatusesCount = (await _nahhas.VideoService.CountAsync()) + 
                                     (await _nahhas.ImageService.CountAsync()) + 
                                     (await _nahhas.QuoteService.CountAsync())
            });

        public async Task<IActionResult> Download(string path)
            => File(await _nahhas.FileService.DownloadAsync(path),
                MediaTypeNames.Application.Octet, Path.GetFileName(path));

        public IActionResult Privacy()
            => View();

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
            => View(new ErrorViewModel
            {
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            });
    }
}