using Nahhas.API.Controllers.Base;
using Nahhas.Library.Entities;
using Nahhas.Library.Filters.Entity;
using Nahhas.Library.Repositories.Interfaces;

namespace Nahhas.API.Controllers
{
    public class CategoriesController : ControllerBase<Category, CategoryFilter>
    {
        public CategoriesController(IGenericRepository<Category> repository) : base(repository) { }
    }
}