using Nahhas.Business.Entities.Base;

namespace Nahhas.Business.Entities
{
    public class Category : EntityBase
    {
        public string Name { get; set; }
        public string CoverPath { get; set; }
        public decimal StatusCount { get; set; }
    }
}