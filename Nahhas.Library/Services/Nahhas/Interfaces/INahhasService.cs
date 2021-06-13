using Nahhas.Library.Entities.Interfaces;
using Nahhas.Library.Filters.Entity.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Nahhas.Library.Services.Nahhas.Interfaces
{
    public interface INahhasService<T> where T : IEntity
    {
        Task<IEnumerable<T>> GetAsync();
        Task<IEnumerable<T>> GetAsync(IFilter<T> filter);
        Task<T> GetAsync(Guid id);
        Task<T> AddAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task<T> DeleteAsync(Guid id);

        Task<decimal> CountAsync(IFilter<T> filter = null);
    }
}