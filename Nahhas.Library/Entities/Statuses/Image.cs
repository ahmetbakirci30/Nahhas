using Nahhas.Library.Entities.Statuses.Base;
using System.ComponentModel.DataAnnotations;

namespace Nahhas.Library.Entities.Statuses
{
    public class Image : StatusBase
    {
        [Required]
        public string ImagePath { get; set; }
    }
}