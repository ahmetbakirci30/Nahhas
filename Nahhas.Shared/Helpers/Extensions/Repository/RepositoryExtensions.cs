using Nahhas.Shared.Entities.Base;
using Nahhas.Shared.Filters.Base;
using Nahhas.Shared.Repositories.Interfaces;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Nahhas.Shared.Helpers.Extensions.Repository
{
    public static class RepositoryExtensions
    {
        public static async Task<bool> Exists<T>(this IRepository<T> repository, Guid id) where T : EntityBase
            => (await repository.Get(new FilterBase<T> { Id = id })).SingleOrDefault() != null;
    }
}