using Microsoft.EntityFrameworkCore;
using SSP.Order.Domain.Repositories;
using SSP.Order.Infrastructure.Data;
using SSP.Order.Infrastructure.Repositories.Base;
using System;
using System.Linq;
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

        public async Task<Domain.Entities.Order> GetOrderByOrderNumber(string orderNumber)
        {
            var order = await _dbContext.Orders.Where(o => o.OrderNumber == orderNumber).FirstOrDefaultAsync();
            if (order == null)
                return null;

            return order;
        }
        #endregion
    }
}
