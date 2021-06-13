using Nahhas.Library.Entities.Statuses.Base;
using System.ComponentModel.DataAnnotations;

namespace Nahhas.Library.Entities.Statuses
{
    public class Quote : StatusBase
    {
        [Required]
        public string Content { get; set; }
    }
}