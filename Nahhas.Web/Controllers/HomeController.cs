using Microsoft.AspNetCore.Mvc;
using Nahhas.Business.Repositories.Interfaces;
using Nahhas.Web.Models;
using System.Diagnostics;
using System.IO;
using System.Net.Mime;
using System.Threading.Tasks;

namespace Nahhas.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly INahhasRepositories _nahhas;

        public HomeController(INahhasRepositories nahhas)
        {
            _nahhas = nahhas;
        }

        public async Task<IActionResult> Index()
            => View(new NahhasStatuses
            {
                Videos = await _nahhas.VideoRepository.Get(),
                Images = await _nahhas.ImageRepository.Get(),
                Quotes = await _nahhas.QuoteRepository.Get(),

                TotalStatusesCount = (await _nahhas.VideoRepository.Count()) + (await _nahhas.ImageRepository.Count()) + (await _nahhas.QuoteRepository.Count())
            });

        public async Task<IActionResult> Download(string path)
            => File(await _nahhas.FileRepository.Download(path),
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