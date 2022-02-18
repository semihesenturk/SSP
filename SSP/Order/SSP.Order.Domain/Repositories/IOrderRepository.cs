using SSP.Order.Domain.Repositories.Base;
using System.Threading.Tasks;

namespace SSP.Order.Domain.Repositories
{
    public interface IOrderRepository : IRepository<Entities.Order>
    {
        Task<Entities.Order> GetOrderByOrderNumber();
    }
}
