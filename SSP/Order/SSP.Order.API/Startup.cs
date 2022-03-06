using AutoMapper;
using MassTransit;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using SSP.Order.API.Consumers;
using SSP.Order.API.Mapper;
using SSP.Order.API.Middlewares;
using SSP.Order.Application;
using SSP.Order.Infrastructure;
using SSP.Order.Shared.Settings;
using System.Reflection;

namespace SSP.Order.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddHealthChecks();

            services.AddSingleton(sp => Configuration);

            services.AddLogging();

            //Add Masstransit
            services.AddMassTransit(x =>
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
            services.AddMassTransitHostedService();

            //Add infrastructure layer
            services.AddInfrastructure(Configuration);

            //Add application layer
            services.AddApplication();

            //Add swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "SSP.Order.API", Version = "v1" });
            });

            //Configure Mapper
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            var config = new MapperConfiguration(cfg =>
            {
                cfg.ShouldMapProperty = p => p.GetMethod.IsPublic || p.GetMethod.IsAssembly;
                cfg.AddProfile<OrderMappingProfile>();
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //For api healthcheck
            app.UseHealthChecks("api/health", new Microsoft.AspNetCore.Diagnostics.HealthChecks.HealthCheckOptions()
            {
                ResponseWriter = async (context, report) =>
                {
                    await context.Response.WriteAsync("OK");
                }
            });

            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "SSP.Order.API v1"));

            //app.UseHttpsRedirection();

            //Add middlewares
            app.UseMiddleware<ExceptionHandlerMiddleWare>();
            app.UseMiddleware<RequestResponseMiddleWare>();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
