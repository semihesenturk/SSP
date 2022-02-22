using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SSP.Order.Domain.Repositories;
using SSP.Order.Domain.Repositories.Base;
using SSP.Order.Infrastructure.Data;
using SSP.Order.Infrastructure.Repositories;
using SSP.Order.Infrastructure.Repositories.Base;

namespace SSP.Order.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            #region InMemoryDb
            services.AddDbContext<OrderContext>(opt => opt.UseInMemoryDatabase(databaseName: "InMemoryDb"),
                ServiceLifetime.Singleton,
                ServiceLifetime.Singleton);
            #endregion

            #region MsSqlServer
            //services.AddDbContext<OrderContext>(options =>
            //   options.UseSqlServer(
            //       configuration.GetConnectionString("OrderConnection"),
            //       b => b.MigrationsAssembly(typeof(OrderContext).Assembly.FullName)), ServiceLifetime.Singleton); 
            #endregion

            #region Repositories
            services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
            services.AddTransient<IOrderRepository, OrderRepository>();
            #endregion

            return services;
        }
    }
}
