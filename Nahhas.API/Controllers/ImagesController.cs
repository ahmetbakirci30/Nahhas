using Nahhas.API.Controllers.Base;
using Nahhas.Shared.Entities;
using Nahhas.Shared.Filters;
using Nahhas.Shared.Repositories.Interfaces;

namespace Nahhas.API.Controllers
{
    public class ImagesController : ControllerBase<Image, ImageFilter>
    {
        public ImagesController(IRepository<Image> repository) : base(repository) { }
    }
}