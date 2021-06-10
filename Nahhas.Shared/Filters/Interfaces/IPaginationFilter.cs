using System.Linq;

namespace Nahhas.Shared.Filters.Interfaces
{
    public interface IPaginationFilter<T> where T : class
    {
        int PageNumber { get; set; }
        int PageSize { get; set; }

        IQueryable<T> ConfigurePagination(IQueryable<T> data);
    }
}