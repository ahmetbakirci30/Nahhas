using Nahhas.Business.Entities;
using Nahhas.Business.Repositories.Interfaces;
using Nahhas.Business.Services.File;
using Nahhas.Business.Services.File.Interfaces;
using Nahhas.Business.Services.Http;
using Nahhas.Business.Services.Http.Interfaces;
using Nahhas.Business.Services.Nahhas;
using Nahhas.Business.Services.Nahhas.Interfaces;

namespace Nahhas.Business.Repositories
{
    public class NahhasRepositories : INahhasRepositories
    {
        private readonly IHttpService _service;

        public NahhasRepositories()
        {
            _service = new HttpService();
        }

        public INahhasService<Category> CategoryRepository => new NahhasService<Category>(_service, "categories");
        public INahhasService<Video> VideoRepository => new NahhasService<Video>(_service, "videos");
        public INahhasService<Image> ImageRepository => new NahhasService<Image>(_service, "images");
        public INahhasService<Quote> QuoteRepository => new NahhasService<Quote>(_service, "quotes");
        public IFileService FileRepository => new FileService(_service, "files");
    }
}