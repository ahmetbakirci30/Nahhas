using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Nahhas.Shared.Entities;
using Nahhas.Shared.Repositories;
using Nahhas.Web.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Nahhas.Web.Controllers
{
    public class DashboardController : Controller
    {
        private readonly NahhasRepositories _nahhas;

        public DashboardController(NahhasRepositories nahhas)
        {
            _nahhas = nahhas;
        }

        // GET: DashboardController
        public async Task<ActionResult> Index()
        {
            var videos = await _nahhas.VideoRepository.Get();
            var categories = await _nahhas.CategoryRepository.Get();

            foreach (var video in videos)
                video.Category = categories.SingleOrDefault(c => c.Id == video.CategoryId);

            return View(videos);
        }

        // GET: DashboardController/Details/5
        public async Task<ActionResult> Details(Guid id)
        {
            var video = await _nahhas.VideoRepository.Get(id);
            video.Category = await _nahhas.CategoryRepository.Get(video.CategoryId);

            return View(video);
        }

        // GET: DashboardController/Create
        public async Task<ActionResult> Create()
        {
            var categories = await _nahhas.CategoryRepository.Get();
            ViewBag.Categories = new SelectList(categories, "Id", "Name");
            return View();
        }

        // POST: DashboardController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(VideoViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return RedirectToAction(nameof(Create));

                var videoPath = await _nahhas.FileRepository.Add(model.VideoFile);
                var imagePath = await _nahhas.FileRepository.Add(model.CoverFile);

                var video = new Video
                {
                    Active = model.Active,
                    CategoryId = model.CategoryId,
                    Title = model.Title,
                    VideoPath = videoPath,
                    CoverPath = imagePath
                };

                await new NahhasRepositories().VideoRepository.Add(video);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return RedirectToAction(nameof(Create));
            }
        }

        // GET: DashboardController/Edit/5
        public async Task<ActionResult> Edit(Guid id)
        {
            var video = await new NahhasRepositories().VideoRepository.Get(id);

            var categories = await _nahhas.CategoryRepository.Get();
            ViewBag.Categories = new SelectList(categories, "Id", "Name");

            return View(new VideoViewModel
            {
                Id = video.Id,
                Active = video.Active,
                Title = video.Title,
                CategoryId = video.CategoryId,
                VideoPath = video.VideoPath,
                CoverPath = video.CoverPath
            });
        }

        // POST: DashboardController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Guid id, VideoViewModel model)
        {
            try
            {
                var videoPath = (model.VideoFile != null) ? await _nahhas.FileRepository.Add(model.VideoFile) : string.Empty;
                var coverPath = (model.CoverFile != null) ? await _nahhas.FileRepository.Add(model.CoverFile) : string.Empty;

                var video = new Video
                {
                    Id = model.Id,
                    Active = model.Active,
                    CategoryId = model.CategoryId,
                    Title = model.Title,
                    VideoPath = string.IsNullOrWhiteSpace(videoPath) ? model.VideoPath : videoPath,
                    CoverPath = string.IsNullOrWhiteSpace(coverPath) ? model.CoverPath : coverPath
                };

                await new NahhasRepositories().VideoRepository.Update(video);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return RedirectToAction(nameof(Edit));
            }
        }

        // GET: DashboardController/Delete/5
        public async Task<ActionResult> Delete(Guid id)
        {
            return View(await new NahhasRepositories().VideoRepository.Get(id));
        }

        // POST: DashboardController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(Guid id, IFormCollection collection)
        {
            try
            {
                await new NahhasRepositories().VideoRepository.Delete(id);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}