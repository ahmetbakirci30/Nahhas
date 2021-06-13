using Nahhas.Library.Entities;
using Nahhas.Library.Entities.Statuses;
using Nahhas.Library.Services.Files.Interfaces;
using Nahhas.Library.Services.Nahhas.Interfaces;

namespace Nahhas.Library.Services.Client.Interfaces
{
    public interface INahhasServices
    {
        INahhasService<Category> CategoryService { get; }
        INahhasService<Video> VideoService { get; }
        INahhasService<Image> ImageService { get; }
        INahhasService<Quote> QuoteService { get; }
        IFileService FileService { get; }
    }
}