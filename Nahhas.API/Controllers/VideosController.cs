using Nahhas.API.Controllers.Base;
using Nahhas.Library.Entities.Statuses;
using Nahhas.Library.Filters.Entity.Statuses;
using Nahhas.Library.Repositories.Interfaces;

namespace Nahhas.API.Controllers
{
    public class VideosController : ControllerBase<Video, VideoFilter>
    {
        public VideosController(IGenericRepository<Video> repository) : base(repository) { }
    }
}