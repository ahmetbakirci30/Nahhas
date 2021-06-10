using System;

namespace Nahhas.Business.Entities.Base
{
    public abstract class EntityBase
    {
        public Guid Id { get; set; }
        public DateTime AdditionDate { get; set; }
        public DateTime LastModified { get; set; }
        public bool Active { get; set; } = true;
    }
}