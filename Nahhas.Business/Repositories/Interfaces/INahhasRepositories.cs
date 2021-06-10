using Nahhas.Business.Entities;

namespace Nahhas.Business.Repositories.Interfaces
{
    public interface INahhasRepositories
    {
        IRepository<Category> CategoryRepository { get; }
        IRepository<Video> VideoRepository { get; }
        IRepository<Image> ImageRepository { get; }
        IRepository<Quote> QuoteRepository { get; }
        IRepository<FormFile> FileRepository { get; }
    }
}