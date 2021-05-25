using Nahhas.API.Controllers.Base;
using Nahhas.Shared.Entities;
using Nahhas.Shared.Filters;
using Nahhas.Shared.Repositories.Interfaces;

namespace Nahhas.API.Controllers
{
    public class CategoriesController : ControllerBase<Category, CategoryFilter>
    {
        public CategoriesController(IRepository<Category> repository) : base(repository) { }
    }
}