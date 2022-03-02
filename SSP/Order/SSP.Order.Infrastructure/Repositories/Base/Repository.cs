using Microsoft.EntityFrameworkCore;
using SSP.Order.Domain.Repositories.Base;
using SSP.Order.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SSP.Order.Infrastructure.Repositories.Base
{
    public class Repository<T> : IRepository<T> where T : Domain.Entities.Base.Entity
    {
        #region Variables
        protected readonly OrderContext _dbContext;
        #endregion

        #region Constructor
        public Repository(OrderContext context)
        {
            _dbContext = context;
        }
        #endregion


        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public async Task<IEnumerable<T>> GetAsync(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            return await _dbContext.Set<T>().Where(predicate).ToListAsync();
        }

        public async Task<IEnumerable<T>> GetAsync(System.Linq.Expressions.Expression<Func<T, bool>> predicate = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeString = null, bool disableTracking = true)
        {
            IQueryable<T> query = _dbContext.Set<T>();

            if (disableTracking)
                query = query.AsNoTracking();

            if (!string.IsNullOrWhiteSpace(includeString)) query = query.Include(includeString);

            if (predicate != null) query = query.Where(predicate);

            if (orderBy != null)
                return await orderBy(query).ToListAsync();

            return await query.ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }



        public async Task<T> AddASync(T entity)
        {
            _dbContext.Set<T>().Add(entity);
            entity.CreatedUserId = 1;
            await _dbContext.SaveChangesAsync();

            return entity;
        }
        public async Task UpdateAsync(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            entity.UpdatedTime = DateTime.Now;
            entity.UpdatedUserId = 1;

            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}
