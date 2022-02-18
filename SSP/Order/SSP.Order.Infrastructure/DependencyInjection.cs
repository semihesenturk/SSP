using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SSP.Order.Domain.Repositories;
using SSP.Order.Infrastructure.Data;
using SSP.Order.Infrastructure.Repositories;

namespace SSP.Order.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<OrderContext>(opt => opt.UseInMemoryDatabase(databaseName: "InMemoryDb"),
                ServiceLifetime.Singleton,
                ServiceLifetime.Singleton);

            //Add Repositories
            services.AddScoped<IOrderRepository, OrderRepository>();

            return services;
        }
    }
}
