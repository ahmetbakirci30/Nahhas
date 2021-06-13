using Nahhas.Library.Entities.Interfaces;
using System.Linq;

namespace Nahhas.Library.Filters.Pagination.Interfaces
{
    public interface IPaginationFilter<T> where T : IEntity
    {
        int PageNumber { get; set; }
        int PageSize { get; set; }

        IQueryable<T> ConfigurePagination(IQueryable<T> initialSet);
    }
}