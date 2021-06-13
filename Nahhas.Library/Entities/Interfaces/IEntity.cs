using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Nahhas.Library.Entities.Interfaces
{
    public interface IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        Guid Id { get; set; }
        DateTime? AdditionDate { get; set; }
        DateTime? LastModified { get; set; }
        bool Active { get; set; }
    }
}