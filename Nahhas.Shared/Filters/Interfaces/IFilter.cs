using System.Linq;

namespace Nahhas.Shared.Filters.Interfaces
{
    public interface IFilter<T> where T : class
    {
        IQueryable<T> Build(IQueryable<T> data, bool applyPagination = true);
    }
}