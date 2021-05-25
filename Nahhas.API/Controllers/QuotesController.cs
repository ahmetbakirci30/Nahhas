using Nahhas.API.Controllers.Base;
using Nahhas.Shared.Entities;
using Nahhas.Shared.Filters;
using Nahhas.Shared.Repositories.Interfaces;

namespace Nahhas.API.Controllers
{
    public class QuotesController : ControllerBase<Quote, QuoteFilter>
    {
        public QuotesController(IRepository<Quote> repository) : base(repository) { }
    }
}