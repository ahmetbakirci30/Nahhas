using Nahhas.API.Controllers.Base;
using Nahhas.Library.Entities.Statuses;
using Nahhas.Library.Filters.Entity.Statuses;
using Nahhas.Library.Repositories.Interfaces;

namespace Nahhas.API.Controllers
{
    public class ImagesController : ControllerBase<Image, ImageFilter>
    {
        public ImagesController(IGenericRepository<Image> repository) : base(repository) { }
    }
}