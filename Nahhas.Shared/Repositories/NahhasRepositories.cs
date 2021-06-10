using Nahhas.Shared.Entities;

namespace Nahhas.Shared.Repositories
{
    public class NahhasRepositories
    {
        public ApiRepository<Category> CategoryRepository { get => new(); }
        public ApiRepository<Video> VideoRepository { get => new(); }
        public ApiRepository<Image> ImageRepository { get => new(); }
        public ApiRepository<Quote> QuoteRepository { get => new(); }
        public FileRepository FileRepository { get => new(); }
    }
}