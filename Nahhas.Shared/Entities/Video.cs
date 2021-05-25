using Nahhas.Shared.Entities.Base;
using System.ComponentModel.DataAnnotations;

namespace Nahhas.Shared.Entities
{
    public class Video : StatusBase
    {
        [Required]
        [StringLength(255, ErrorMessage = "The {0} value cannot exceed {1} characters.")]
        public string Title { get; set; }

        [Required]
        public string VideoPath { get; set; }

        public string CoverPath { get; set; }
    }
}