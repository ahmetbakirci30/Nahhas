using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Nahhas.Shared.Repositories;
using Nahhas.Web.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;

namespace Nahhas.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly NahhasRepositories _nahhas;
        private readonly FileRepository fileRepository;

        public HomeController(NahhasRepositories nahhas, FileRepository fileRepository)
        {
            _nahhas = nahhas;
            this.fileRepository = fileRepository;
        }

        public async Task<IActionResult> Index()
        {
            return View(new NahhasStatuses
            {
                Videos = await _nahhas.VideoRepository.Get(),
                Images = await _nahhas.ImageRepository.Get(),
                Quotes = await _nahhas.QuoteRepository.Get()
            });
        }

        public async Task<IActionResult> Download(string path)
        {
            var status = await fileRepository.Get(path);
            return File(status, MediaTypeNames.Application.Octet, Path.GetFileName(path));
           // return RedirectToAction(nameof(Index));
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel
            {
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            });
        }
    }
}
