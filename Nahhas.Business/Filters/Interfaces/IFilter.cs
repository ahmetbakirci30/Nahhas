using System.Linq;

namespace Nahhas.Business.Filters.Interfaces
{
    public interface IFilter<T> where T : class
    {
        IQueryable<T> Build(IQueryable<T> data, bool applyPagination = true);
    }
}