﻿using Nahhas.Library.Entities.Base;
using Nahhas.Library.Entities.Statuses.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Nahhas.Library.Entities
{
    public class Category : EntityBase
    {
        [Required]
        [StringLength(255, ErrorMessage = "The {0} value cannot exceed {1} characters.")]
        public string Name { get; set; }

        [Required]
        public string CoverPath { get; set; }

        [Column(TypeName = "decimal(38, 0)")]
        public decimal StatusCount { get; set; }

        public ICollection<StatusBase> Statuses { get; set; }
    }
}