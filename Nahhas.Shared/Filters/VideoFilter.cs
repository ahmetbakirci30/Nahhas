using Nahhas.Shared.Entities;
using Nahhas.Shared.Filters.Base;
using System.Linq;

namespace Nahhas.Shared.Filters
{
    public class VideoFilter : StatusFilter<Video>
    {
        public string Title { get; set; }

        public override IQueryable<Video> Build(IQueryable<Video> data, bool applyPagination = true)
        {
            data = (!string.IsNullOrWhiteSpace(Title)) ?
                   data.Where(v => v.Title.ToLower().Contains(Title.ToLower())) : data;

            return base.Build(data, applyPagination);
        }
    }
}