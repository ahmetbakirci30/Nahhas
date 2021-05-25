using Nahhas.Shared.Entities.Base;
using System.ComponentModel.DataAnnotations;

namespace Nahhas.Shared.Entities
{
    public class Image : StatusBase
    {
        [Required]
        public string ImagePath { get; set; }
    }
}