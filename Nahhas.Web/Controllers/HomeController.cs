using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Nahhas.Shared.Repositories;
using Nahhas.Web.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Nahhas.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly NahhasRepositories _nahhas;

        public HomeController(NahhasRepositories nahhas)
        {
            _nahhas = nahhas;
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
