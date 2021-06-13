using Nahhas.Business.Entities;
using Nahhas.Business.Services.File.Interfaces;
using Nahhas.Business.Services.Nahhas.Interfaces;

namespace Nahhas.Business.Repositories.Interfaces
{
    public interface INahhasRepositories
    {
        INahhasService<Category> CategoryRepository { get; }
        INahhasService<Video> VideoRepository { get; }
        INahhasService<Image> ImageRepository { get; }
        INahhasService<Quote> QuoteRepository { get; }
        IFileService FileRepository { get; }
    }
}