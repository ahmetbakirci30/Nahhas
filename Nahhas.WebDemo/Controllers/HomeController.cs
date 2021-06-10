using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Nahhas.Business.Repositories.Interfaces;
using Nahhas.WebDemo.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Nahhas.WebDemo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly INahhasRepositories _nahhas;

        public HomeController(ILogger<HomeController> logger, INahhasRepositories nahhas)
        {
            _logger = logger;
            _nahhas = nahhas;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _nahhas.VideoRepository.Get());
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
