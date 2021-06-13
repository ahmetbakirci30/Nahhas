using Nahhas.Library.Entities.Interfaces;
using System.Linq;

namespace Nahhas.Library.Filters.Entity.Interfaces
{
    public interface IFilter<T> where T : IEntity
    {
        IQueryable<T> Build(IQueryable<T> initialSet, bool applyPagination = true);
    }
}