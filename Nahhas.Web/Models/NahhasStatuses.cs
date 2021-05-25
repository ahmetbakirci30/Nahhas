using Nahhas.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nahhas.Web.Models
{
    public class NahhasStatuses
    {
        public IEnumerable<Video> Videos { get; set; }
        public IEnumerable<Image> Images { get; set; }
        public IEnumerable<Quote> Quotes { get; set; }
    }
}