using Nahhas.Library.Entities.Base;
using Nahhas.Library.Filters.Pagination.Interfaces;
using System.Linq;

namespace Nahhas.Library.Filters.Pagination
{
    public abstract class PaginationFilter<T> : IPaginationFilter<T> where T : EntityBase, new()
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
            set => _pageSize = (value > 0) ? value : 9;
        }

        public IQueryable<T> ConfigurePagination(IQueryable<T> initialSet)
            => initialSet.Skip((PageNumber - 1) * PageSize).Take(PageSize);
    }
}