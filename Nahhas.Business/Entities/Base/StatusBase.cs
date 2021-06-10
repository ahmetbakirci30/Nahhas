using System;

namespace Nahhas.Business.Entities.Base
{
    public abstract class StatusBase : EntityBase
    {
        public decimal ViewsCount { get; set; }
        public decimal LikesCount { get; set; }
        public decimal SharesCount { get; set; }
        public decimal DownloadsCount { get; set; }
        public Guid CategoryId { get; set; }
    }
}