using Microsoft.EntityFrameworkCore;

namespace SSP.Order.Infrastructure.Data
{
    public class OrderContext : DbContext
    {
        #region Constructor
        public OrderContext(DbContextOptions options)
           : base(options)
        {

        }
        #endregion

        #region Db Sets
        public DbSet<Domain.Entities.Order> Orders { get; set; } 
        #endregion
    }
}
