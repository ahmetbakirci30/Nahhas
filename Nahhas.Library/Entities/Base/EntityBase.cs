using Nahhas.Library.Entities.Interfaces;
using System;

namespace Nahhas.Library.Entities.Base
{
    public abstract class EntityBase : IEntity
    {
        public Guid Id { get; set; }
        public DateTime? AdditionDate { get; set; }
        public DateTime? LastModified { get; set; }
        public bool Active { get; set; } = true;
    }
}