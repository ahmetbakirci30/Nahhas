using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Nahhas.Business.Entities;
using Nahhas.Business.Repositories.Interfaces;
using Nahhas.Web.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Nahhas.Web.Controllers
{
    public class DashboardController : Controller
    {
        private readonly INahhasRepositories _nahhas;

        public DashboardController(INahhasRepositories nahhas)
        {
            _nahhas = nahhas;
        }

        public async Task<ActionResult> Index()
        {
            var videos = await _nahhas.VideoRepository.Get();
            var categories = await _nahhas.CategoryRepository.Get();

            foreach (var video in videos)
                video.Category = categories.SingleOrDefault(c => c.Id == video.CategoryId);

            return View(videos);
        }

        public async Task<ActionResult> Details(Guid id)
        {
            var video = await _nahhas.VideoRepository.Get(id);
            video.Category = await _nahhas.CategoryRepository.Get(video.CategoryId);

            return View(video);
        }

        public async Task<ActionResult> Create()
        {
            var categories = await _nahhas.CategoryRepository.Get();
            ViewBag.Categories = new SelectList(categories, "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(VideoViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return RedirectToAction(nameof(Create));

                await _nahhas.VideoRepository.Add(new Video
                {
                    Active = model.Active,
                    CategoryId = model.CategoryId,
                    Title = model.Title,
                    VideoPath = await UploadFile(model.VideoFile),
                    CoverPath = await UploadFile(model.CoverFile)
                });

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return RedirectToAction(nameof(Create));
            }
        }

        public async Task<ActionResult> Edit(Guid id)
        {
            ViewBag.Categories = new SelectList(await _nahhas.CategoryRepository.Get(), "Id", "Name");

            var video = await _nahhas.VideoRepository.Get(id);

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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Guid id, VideoViewModel model)
        {
            try
            {
                await _nahhas.VideoRepository.Update(new Video
                {
                    Id = model.Id,
                    Active = model.Active,
                    CategoryId = model.CategoryId,
                    Title = model.Title,
                    VideoPath = await UpdateFile(model.VideoFile, model.VideoPath),
                    CoverPath = await UpdateFile(model.CoverFile, model.CoverPath)
                });

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return RedirectToAction(nameof(Edit));
            }
        }

        public async Task<ActionResult> Delete(Guid id)
            => View(await _nahhas.VideoRepository.Get(id));

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(Guid id, Video video)
        {
            try
            {
                await _nahhas.FileRepository.Delete(video.VideoPath);
                await _nahhas.FileRepository.Delete(video.CoverPath);
                await _nahhas.VideoRepository.Delete(id);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return RedirectToAction(nameof(Delete));
            }
        }

        private async Task<string> UploadFile(IFormFile file)
            => await _nahhas.FileRepository.Upload(file);

        private async Task<string> UpdateFile(IFormFile file, string path)
            => (file != null && file.Length > 0) ? await _nahhas.FileRepository.Update(file, path) : path;
    }
}