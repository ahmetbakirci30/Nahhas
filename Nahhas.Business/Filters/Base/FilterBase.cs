using Nahhas.Business.Entities.Base;
using Nahhas.Business.Filters.Interfaces;
using System;
using System.Linq;

namespace Nahhas.Business.Filters.Base
{
    public class FilterBase<T> : PaginationFilter<T>, IFilter<T> where T : EntityBase
    {
        public Guid? Id { get; set; }
        public DateTime? AdditionDate { get; set; }
        public DateTime? FirstDate { get; set; }
        public DateTime? LastDate { get; set; }
        public bool Active { get; set; } = true;

        public virtual IQueryable<T> Build(IQueryable<T> data, bool applyPagination = true)
        {
            data = (Id.HasValue && !Id.Equals(Guid.Empty)) ?
                data.Where(d => d.Id == Id) : data;

            data = (AdditionDate.HasValue && AdditionDate.Value > DateTime.MinValue && AdditionDate.Value < DateTime.MaxValue) ?
                data.Where(d => d.AdditionDate == AdditionDate) : data;

            data = (FirstDate.HasValue && FirstDate.Value > DateTime.MinValue && FirstDate.Value < DateTime.MaxValue) ?
                data.Where(d => d.AdditionDate >= FirstDate) : data;

            data = (LastDate.HasValue && LastDate.Value > DateTime.MinValue && LastDate.Value < DateTime.MaxValue) ?
                data.Where(d => d.AdditionDate <= LastDate) : data;

            data = data.Where(d => d.Active == Active);

            return applyPagination ? ConfigurePagination(data) : data;
        }
    }
}