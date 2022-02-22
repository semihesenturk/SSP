using Microsoft.EntityFrameworkCore;
using SSP.Order.Domain.Entities;

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
        public DbSet<OrderItem> OrderItems { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderItem>()
                 .HasOne<Domain.Entities.Order>()
                 .WithMany()
                 .HasForeignKey(p => p.OrderId);
        }
    }
}
