using Nahhas.Shared.Entities;
using Nahhas.Shared.Filters.Base;
using System.Linq;

namespace Nahhas.Shared.Filters
{
    public class CategoryFilter : FilterBase<Category>
    {
        public string Name { get; set; }
        public decimal? StatusCount { get; set; }
        public decimal? MinStatusCount { get; set; }
        public decimal? MaxStatusCount { get; set; }

        public override IQueryable<Category> Build(IQueryable<Category> data, bool applyPagination = true)
        {
            data = (!string.IsNullOrWhiteSpace(Name)) ?
                data.Where(d => d.Name.ToLower().Contains(Name.ToLower())) : data;

            data = (StatusCount.HasValue && StatusCount >= 0) ?
                data.Where(d => d.StatusCount == StatusCount) : data;

            data = (MinStatusCount.HasValue && MinStatusCount >= 0) ?
                data.Where(d => d.StatusCount >= MinStatusCount) : data;

            data = (MaxStatusCount.HasValue && MaxStatusCount >= 0) ?
                data.Where(d => d.StatusCount <= MaxStatusCount) : data;

            return base.Build(data, applyPagination);
        }
    }
}