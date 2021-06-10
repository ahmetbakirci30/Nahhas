using Nahhas.Business.Entities.Base;
using Nahhas.Business.Filters.Interfaces;
using System.Linq;

namespace Nahhas.Business.Filters.Base
{
    public abstract class PaginationFilter<T> : IPaginationFilter<T> where T : EntityBase
    {
        private int _pageNumber = 1;
        private int _pageSize = 9;

        public int PageNumber
        {
            get => _pageNumber;
            set => _pageNumber = (value > 0) ? value : 1;
        }
        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = (value > 0) ? value : 1;
        }

        public IQueryable<T> ConfigurePagination(IQueryable<T> data)
            => data.Skip((PageNumber - 1) * PageSize).Take(PageSize);
    }
}