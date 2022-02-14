using SSP.Order.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SSP.Order.Domain.Repositories.Base
{
    public interface IRepository<T> where T : Entity
    {
        Task<IEnumerable<T>> GetAllAsync();

        Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> predicate);

        Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> predicate = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeString = null,
            bool disableTracking = true);

        Task<T> GetByIdAsync(int id);

        Task<T> AddASync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
    }
}
