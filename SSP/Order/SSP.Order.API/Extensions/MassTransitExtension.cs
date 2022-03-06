using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SSP.Order.API.Consumers;
using SSP.Order.Shared.Settings;

namespace SSP.Order.API.Extensions
{
    public static class MassTransitExtension
    {
        public static IConfiguration Configuration { get; set; }

        public static IServiceCollection AddMassTransitConfiguration(this IServiceCollection service)
        {
            service.AddMassTransit(x =>
            {
                x.AddConsumer<OrderCreateMessageConsumer>();
                x.UsingRabbitMq((context, cfg) =>
                {
                    cfg.Host(Configuration.GetConnectionString("RabbitMQ"));
                    cfg.ReceiveEndpoint(RabbitMQSettingsConst.OrderCreateMessageQueueName, e =>
                    {
                        e.ConfigureConsumer<OrderCreateMessageConsumer>(context);
                    });
                });
            });
            service.AddMassTransitHostedService();

            return service;
        }
    }
}
