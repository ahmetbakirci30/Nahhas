using Nahhas.Library.Entities.Base;
using Nahhas.Library.Filters.Entity.Interfaces;
using Nahhas.Library.Filters.Pagination;
using System;
using System.Linq;

namespace Nahhas.Library.Filters.Entity.Base
{
    public abstract class FilterBase<T> : PaginationFilter<T>, IFilter<T> where T : EntityBase, new()
    {
        public Guid? Id { get; set; }
        public DateTime? AdditionDate { get; set; }
        public DateTime? FirstDate { get; set; }
        public DateTime? LastDate { get; set; }
        public bool Active { get; set; } = true;

        public virtual IQueryable<T> Build(IQueryable<T> initialSet, bool applyPagination = true)
        {
            initialSet = (Id.HasValue && !Id.Equals(Guid.Empty)) ?
                initialSet.Where(entity => entity.Id.Equals(Id)) : initialSet;

            initialSet = (AdditionDate.HasValue && AdditionDate.Value > DateTime.MinValue && AdditionDate.Value < DateTime.MaxValue) ?
                initialSet.Where(entity => entity.AdditionDate == AdditionDate) : initialSet;

            initialSet = (FirstDate.HasValue && FirstDate.Value > DateTime.MinValue && FirstDate.Value < DateTime.MaxValue) ?
                initialSet.Where(entity => (entity.AdditionDate >= FirstDate) && (entity.LastModified >= FirstDate)) : initialSet;

            initialSet = (LastDate.HasValue && LastDate.Value > DateTime.MinValue && LastDate.Value < DateTime.MaxValue) ?
                initialSet.Where(entity => (entity.AdditionDate <= LastDate) && (entity.LastModified <= LastDate)) : initialSet;

            initialSet = initialSet.Where(entity => entity.Active.Equals(Active));

            return applyPagination ? ConfigurePagination(initialSet) : initialSet;
        }
    }
}