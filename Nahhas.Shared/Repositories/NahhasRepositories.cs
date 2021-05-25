using Nahhas.Shared.Entities;

namespace Nahhas.Shared.Repositories
{
    public class NahhasRepositories
    {
        public Repository<Category> CategoryRepository { get => new(); }
        public Repository<Video> VideoRepository { get => new(); }
        public Repository<Image> ImageRepository { get => new(); }
        public Repository<Quote> QuoteRepository { get => new(); }
        public FileRepository FileRepository { get => new(); }
    }
}