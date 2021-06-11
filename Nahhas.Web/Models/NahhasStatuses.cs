using Nahhas.Business.Entities;
using System.Collections.Generic;

namespace Nahhas.Web.Models
{
    public class NahhasStatuses
    {
        public IEnumerable<Video> Videos { get; set; }
        public IEnumerable<Image> Images { get; set; }
        public IEnumerable<Quote> Quotes { get; set; }

        public decimal TotalStatusesCount { get; set; }
    }
}