using Nahhas.Business.Entities;
using Nahhas.Business.Filters.Base;
using System.Linq;

namespace Nahhas.Business.Filters
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