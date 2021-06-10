using Nahhas.Shared.Entities;
using Nahhas.Shared.Services.Base;

namespace Nahhas.Shared.Repositories
{
    public class NahhasRepositories
    {
        public StatusesRepository<Category> CategoryRepository { get => new(new HttpServiceBase<Category>()); }
        public StatusesRepository<Video> VideoRepository { get => new(new HttpServiceBase<Video>()); }
        public StatusesRepository<Image> ImageRepository { get => new(new HttpServiceBase<Image>()); }
        public StatusesRepository<Quote> QuoteRepository { get => new(new HttpServiceBase<Quote>()); }
        public FileRepository FileRepository { get => new(); }
    }
}