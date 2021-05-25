using Nahhas.API.Controllers.Base;
using Nahhas.Shared.Entities;
using Nahhas.Shared.Filters;
using Nahhas.Shared.Repositories.Interfaces;

namespace Nahhas.API.Controllers
{
    public class VideosController : ControllerBase<Video, VideoFilter>
    {
        public VideosController(IRepository<Video> repository) : base(repository) { }
    }
}