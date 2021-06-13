using Nahhas.Library.Entities.Statuses.Base;
using System.ComponentModel.DataAnnotations;

namespace Nahhas.Library.Entities.Statuses
{
    public class Video : StatusBase
    {
        [Required]
        [StringLength(255, ErrorMessage = "The {0} value cannot exceed {1} characters.")]
        public string Title { get; set; }

        [Required]
        public string VideoPath { get; set; }

        [Required]
        public string CoverPath { get; set; }
    }
}