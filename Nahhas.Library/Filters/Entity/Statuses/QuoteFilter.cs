using Nahhas.Library.Entities.Statuses;
using Nahhas.Library.Filters.Entity.Statuses.Base;
using System.Linq;

namespace Nahhas.Library.Filters.Entity.Statuses
{
    public class QuoteFilter : StatusFilter<Quote>
    {
        public string Content { get; set; }

        public override IQueryable<Quote> Build(IQueryable<Quote> quotes, bool applyPagination = true)
        {
            quotes = string.IsNullOrWhiteSpace(Content) ? quotes :
                quotes.Where(quote => quote.Content.ToLower().Contains(Content.ToLower()));

            return base.Build(quotes, applyPagination);
        }
    }
}