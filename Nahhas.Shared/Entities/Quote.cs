using Nahhas.Shared.Entities.Base;
using System.ComponentModel.DataAnnotations;

namespace Nahhas.Shared.Entities
{
    public class Quote : StatusBase
    {
        [Required]
        public string Content { get; set; }
    }
}