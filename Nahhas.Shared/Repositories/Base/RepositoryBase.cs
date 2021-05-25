using Microsoft.EntityFrameworkCore;
using Nahhas.Shared.Entities.Base;
using Nahhas.Shared.Filters.Interfaces;
using Nahhas.Shared.Repositories.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Nahhas.Shared.Repositories.Base
{
    public class RepositoryBase<T> : IRepository<T> where T : EntityBase, new()
    {
        private readonly NahhasDbContext _context;
        private readonly DbSet<T> _table;

        public RepositoryBase(NahhasDbContext context)
        {
            _context = context;
            _table = _context.Set<T>();
        }

        public async Task<IEnumerable<T>> Get()
            => await _table.ToListAsync();

        public async Task<IEnumerable<T>> Get(IFilter<T> filter)
            => await filter.Build(_table).ToListAsync();

        public async Task<T> Get(object id)
            => await _table.FindAsync(id);

        public async Task<decimal> Count(IFilter<T> filter = null) => (filter == null) ?
            await _table.CountAsync() : await filter.Build(_table, false).CountAsync();

        public async Task<T> Add(T entity)
        {
            var added = await _table.AddAsync(entity);
            await _context.SaveChangesAsync();
            return added.Entity;
        }

        public async Task<T> Update(T entity)
        {
            var updated = _table.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return updated.Entity;
        }

        public async Task<T> Delete(object id)
        {
            var deleted = _table.Remove(await Get(id));
            await _context.SaveChangesAsync();
            return deleted.Entity;
        }
    }
}