using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SSP.Order.Infrastructure.Data;
using System;

namespace SSP.Order.API.Extensions
{
    public static class MigrationManager
    {
        public static IHost MigrateDatabase(this IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                try
                {
                    OrderContext orderContext = scope.ServiceProvider.GetRequiredService<OrderContext>();
                    if (orderContext.Database.ProviderName != "Microsoft.EntityFrameworkCore.InMemory")
                    {
                        orderContext.Database.Migrate();
                    }

                    OrderContextSeed.SeedAsync(orderContext)
                        .Wait();
                }
                catch (Exception)
                {
                    throw;
                }
                return host;
            }
        }
    }
}
