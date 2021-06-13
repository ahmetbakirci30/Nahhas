using Nahhas.Library.Entities;
using Nahhas.Library.Entities.Statuses;
using Nahhas.Library.Services.Client.Interfaces;
using Nahhas.Library.Services.Files;
using Nahhas.Library.Services.Files.Interfaces;
using Nahhas.Library.Services.Http;
using Nahhas.Library.Services.Http.Interfaces;
using Nahhas.Library.Services.Nahhas;
using Nahhas.Library.Services.Nahhas.Interfaces;

namespace Nahhas.Library.Services.Client
{
    public class NahhasServices : INahhasServices
    {
        private readonly IHttpService _service;

        public NahhasServices()
        {
            _service = new HttpService();
        }

        public INahhasService<Category> CategoryService => new NahhasService<Category>(_service, "categories");
        public INahhasService<Video> VideoService => new NahhasService<Video>(_service, "videos");
        public INahhasService<Image> ImageService => new NahhasService<Image>(_service, "images");
        public INahhasService<Quote> QuoteService => new NahhasService<Quote>(_service, "quotes");
        public IFileService FileService => new FileService(_service, "files");
    }
}