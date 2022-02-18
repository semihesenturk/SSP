using SSP.Order.Domain.Repositories;
using SSP.Order.Infrastructure.Data;
using SSP.Order.Infrastructure.Repositories.Base;
using System.Threading.Tasks;

namespace SSP.Order.Infrastructure.Repositories
{
    public class OrderRepository : Repository<Domain.Entities.Order>, IOrderRepository
    {
        #region Constructor
        public OrderRepository(OrderContext dbContext)
            : base(dbContext)
        {
            
        }

        public Task<Domain.Entities.Order> GetOrderByOrderNumber()
        {
            throw new System.NotImplementedException();
        }
        #endregion
    }
}
