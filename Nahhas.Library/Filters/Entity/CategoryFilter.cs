using Nahhas.Library.Entities;
using Nahhas.Library.Filters.Entity.Base;
using System.Linq;

namespace Nahhas.Library.Filters.Entity
{
    public class CategoryFilter : FilterBase<Category>
    {
        public string Name { get; set; }
        public decimal? StatusCount { get; set; }
        public decimal? MinStatusCount { get; set; }
        public decimal? MaxStatusCount { get; set; }

        public override IQueryable<Category> Build(IQueryable<Category> categories, bool applyPagination = true)
        {
            categories = string.IsNullOrWhiteSpace(Name) ? categories :
                categories.Where(category => category.Name.ToLower().Contains(Name.ToLower()));

            categories = (StatusCount.HasValue && StatusCount >= 0) ?
                categories.Where(category => category.StatusCount == StatusCount) : categories;

            categories = (MinStatusCount.HasValue && MinStatusCount >= 0) ?
                categories.Where(category => category.StatusCount >= MinStatusCount) : categories;

            categories = (MaxStatusCount.HasValue && MaxStatusCount >= 0) ?
                categories.Where(category => category.StatusCount <= MaxStatusCount) : categories;

            return base.Build(categories, applyPagination);
        }
    }
}