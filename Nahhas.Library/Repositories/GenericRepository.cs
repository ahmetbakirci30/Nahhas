using Microsoft.EntityFrameworkCore;
using Nahhas.Library.Entities.Base;
using Nahhas.Library.Filters.Entity.Interfaces;
using Nahhas.Library.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Nahhas.Library.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : EntityBase, new()
    {
        private readonly NahhasDbContext _context;
        private readonly DbSet<T> _table;

        public GenericRepository(NahhasDbContext context)
        {
            _context = context;
            _table = _context.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAsync()
            => await _table.ToListAsync();

        public async Task<IEnumerable<T>> GetAsync(IFilter<T> filter)
            => await filter.Build(_table).ToListAsync();

        public async Task<T> GetAsync(Guid id)
            => await _table.FindAsync(id);

        public async Task<decimal> CountAsync(IFilter<T> filter = null) => (filter == null) ?
            await _table.CountAsync() : await filter.Build(_table, false).CountAsync();

        public async Task<T> AddAsync(T entity)
        {
            var added = _context.Entry(entity);
            added.State = EntityState.Added;
            await _context.SaveChangesAsync();
            return added.Entity;
        }

        public async Task<T> UpdateAsync(T entity)
        {
            var updated = _context.Entry(entity);
            updated.State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return updated.Entity;
        }

        public async Task<T> DeleteAsync(Guid id)
        {
            var deleted = _context.Entry(await GetAsync(id));
            deleted.State = EntityState.Deleted;
            await _context.SaveChangesAsync();
            return deleted.Entity;
        }

        public async Task<bool> ExistsAsync(Guid id)
            => await _table.AnyAsync(e => e.Id.Equals(id));
    }
}