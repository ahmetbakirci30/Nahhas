using Nahhas.Business.Entities;
using Nahhas.Business.Filters.Base;
using System.Linq;

namespace Nahhas.Business.Filters
{
    public class QuoteFilter : StatusFilter<Quote>
    {
        public string Content { get; set; }

        public override IQueryable<Quote> Build(IQueryable<Quote> data, bool applyPagination = true)
        {
            data = (!string.IsNullOrWhiteSpace(Content)) ?
                   data.Where(q => q.Content.ToLower().Contains(Content.ToLower())) : data;

            return base.Build(data, applyPagination);
        }
    }
}