using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Nahhas.Shared.Entities.Base
{
    public abstract class EntityBase
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public DateTime AdditionDate { get; set; }
        public DateTime LastModified { get; set; }
        public bool Active { get; set; } = true;
    }
}