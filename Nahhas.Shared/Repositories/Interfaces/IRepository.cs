using Nahhas.Shared.Filters.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Nahhas.Shared.Repositories.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> Get();
        Task<IEnumerable<T>> Get(IFilter<T> filter);
        Task<T> Get(object id);

        Task<T> Add(T entity);
        Task<T> Update(T entity);
        Task<T> Delete(object id);

        Task<decimal> Count(IFilter<T> filter = null);
    }
}