using SSP.Order.Domain.Repositories;
using SSP.Order.Infrastructure.Data;
using SSP.Order.Infrastructure.Repositories.Base;

namespace SSP.Order.Infrastructure.Repositories
{
    public class OrderRepository : Repository<Domain.Entities.Order>, IOrderRepository
    {
        #region Constructor
        public OrderRepository(OrderContext dbContext)
            : base(dbContext)
        {
            
        }
        #endregion
    }
}
