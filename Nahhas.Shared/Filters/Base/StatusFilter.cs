using Nahhas.Shared.Entities.Base;
using System;
using System.Linq;

namespace Nahhas.Shared.Filters.Base
{
    public abstract class StatusFilter<T> : FilterBase<T> where T : StatusBase, new()
    {
        public decimal? ViewsCount { get; set; }
        public decimal? MinViewsCount { get; set; }
        public decimal? MaxViewsCount { get; set; }
        public decimal? LikesCount { get; set; }
        public decimal? MinLikesCount { get; set; }
        public decimal? MaxLikesCount { get; set; }
        public decimal? SharesCount { get; set; }
        public decimal? MinSharesCount { get; set; }
        public decimal? MaxSharesCount { get; set; }
        public decimal? DownloadsCount { get; set; }
        public decimal? MinDownloadsCount { get; set; }
        public decimal? MaxDownloadsCount { get; set; }
        public Guid? CategoryId { get; set; }

        public override IQueryable<T> Build(IQueryable<T> data, bool applyPagination = true)
        {
            data = (ViewsCount.HasValue && ViewsCount >= 0) ?
                data.Where(s => s.ViewsCount == ViewsCount) : data;

            data = (MinViewsCount.HasValue && MinViewsCount >= 0) ?
                data.Where(s => s.ViewsCount >= MinViewsCount) : data;

            data = (MaxViewsCount.HasValue && MaxViewsCount >= 0) ?
                data.Where(s => s.ViewsCount <= MaxViewsCount) : data;

            data = (LikesCount.HasValue && LikesCount >= 0) ?
                data.Where(s => s.LikesCount == LikesCount) : data;

            data = (MinLikesCount.HasValue && MinLikesCount >= 0) ?
                data.Where(s => s.LikesCount >= MinLikesCount) : data;

            data = (MaxLikesCount.HasValue && MaxLikesCount >= 0) ?
                data.Where(s => s.LikesCount <= MaxLikesCount) : data;

            data = (SharesCount.HasValue && SharesCount >= 0) ?
                data.Where(s => s.SharesCount == SharesCount) : data;

            data = (MinSharesCount.HasValue && MinSharesCount >= 0) ?
                data.Where(s => s.SharesCount >= MinSharesCount) : data;

            data = (MaxSharesCount.HasValue && MaxSharesCount >= 0) ?
                data.Where(s => s.SharesCount <= MaxSharesCount) : data;

            data = (DownloadsCount.HasValue && DownloadsCount >= 0) ?
                data.Where(s => s.DownloadsCount == DownloadsCount) : data;

            data = (MinDownloadsCount.HasValue && MinDownloadsCount >= 0) ?
                data.Where(s => s.DownloadsCount >= MinDownloadsCount) : data;

            data = (MaxDownloadsCount.HasValue && MaxDownloadsCount >= 0) ?
                data.Where(s => s.DownloadsCount <= MaxDownloadsCount) : data;

            data = (CategoryId.HasValue && CategoryId != Guid.Empty) ?
                data.Where(s => s.CategoryId == CategoryId) : data;

            return base.Build(data, applyPagination);
        }
    }
}