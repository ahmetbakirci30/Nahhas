using Nahhas.Business.Entities;
using Nahhas.Business.Repositories.Interfaces;
using Nahhas.Business.Services;
using Nahhas.Business.Services.Interfaces;

namespace Nahhas.Business.Repositories
{
    public class NahhasRepositories : INahhasRepositories
    {
        private readonly IHttpService _service;

        public NahhasRepositories()
        {
            _service = new HttpService();
        }

        public IRepository<Category> CategoryRepository => new Repository<Category>(_service, "categories");
        public IRepository<Video> VideoRepository => new Repository<Video>(_service, "videos");
        public IRepository<Image> ImageRepository => new Repository<Image>(_service, "images");
        public IRepository<Quote> QuoteRepository => new Repository<Quote>(_service, "quotes");
        public IRepository<FormFile> FileRepository => new Repository<FormFile>(_service, "files");
    }
}