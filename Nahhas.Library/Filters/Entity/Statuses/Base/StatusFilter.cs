using Nahhas.Library.Entities.Statuses.Base;
using Nahhas.Library.Filters.Entity.Base;
using System;
using System.Linq;

namespace Nahhas.Library.Filters.Entity.Statuses.Base
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

        public override IQueryable<T> Build(IQueryable<T> initialSet, bool applyPagination = true)
        {
            initialSet = (ViewsCount.HasValue && ViewsCount >= 0) ?
                initialSet.Where(s => s.ViewsCount.Equals(ViewsCount)) : initialSet;

            initialSet = (MinViewsCount.HasValue && MinViewsCount >= 0) ?
                initialSet.Where(s => s.ViewsCount >= MinViewsCount) : initialSet;

            initialSet = (MaxViewsCount.HasValue && MaxViewsCount >= 0) ?
                initialSet.Where(s => s.ViewsCount <= MaxViewsCount) : initialSet;

            initialSet = (LikesCount.HasValue && LikesCount >= 0) ?
                initialSet.Where(s => s.LikesCount.Equals(LikesCount)) : initialSet;

            initialSet = (MinLikesCount.HasValue && MinLikesCount >= 0) ?
                initialSet.Where(s => s.LikesCount >= MinLikesCount) : initialSet;

            initialSet = (MaxLikesCount.HasValue && MaxLikesCount >= 0) ?
                initialSet.Where(s => s.LikesCount <= MaxLikesCount) : initialSet;

            initialSet = (SharesCount.HasValue && SharesCount >= 0) ?
                initialSet.Where(s => s.SharesCount.Equals(SharesCount)) : initialSet;

            initialSet = (MinSharesCount.HasValue && MinSharesCount >= 0) ?
                initialSet.Where(s => s.SharesCount >= MinSharesCount) : initialSet;

            initialSet = (MaxSharesCount.HasValue && MaxSharesCount >= 0) ?
                initialSet.Where(s => s.SharesCount <= MaxSharesCount) : initialSet;

            initialSet = (DownloadsCount.HasValue && DownloadsCount >= 0) ?
                initialSet.Where(s => s.DownloadsCount.Equals(DownloadsCount)) : initialSet;

            initialSet = (MinDownloadsCount.HasValue && MinDownloadsCount >= 0) ?
                initialSet.Where(s => s.DownloadsCount >= MinDownloadsCount) : initialSet;

            initialSet = (MaxDownloadsCount.HasValue && MaxDownloadsCount >= 0) ?
                initialSet.Where(s => s.DownloadsCount <= MaxDownloadsCount) : initialSet;

            initialSet = (CategoryId.HasValue && !CategoryId.Equals(Guid.Empty)) ?
                initialSet.Where(s => s.CategoryId.Equals(CategoryId)) : initialSet;

            return base.Build(initialSet, applyPagination);
        }
    }
}