using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;

namespace Nahhas.Web.Models
{
    public class VideoViewModel
    {
        public Guid Id { get; set; }
        public bool Active { get; set; } = true;
        public Guid CategoryId { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public IFormFile VideoFile { get; set; }

        [Required]
        public IFormFile CoverFile { get; set; }

        public string VideoPath { get; set; }
        public string CoverPath { get; set; }
    }
}