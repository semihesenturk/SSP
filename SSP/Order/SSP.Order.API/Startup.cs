using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SSP.Order.API.Extensions;
using SSP.Order.API.Middlewares;
using SSP.Order.API.Models.RequestModels;
using SSP.Order.API.Validations;
using SSP.Order.Application;
using SSP.Order.Infrastructure;

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
            services.AddControllers()
                .AddFluentValidation(i => i.RunDefaultMvcValidationAfterFluentValidationExecutes = false);

            services.AddHealthChecks();

            services.AddSingleton(sp => Configuration);

            services.AddLogging();

            //Add Masstransit
            MassTransitExtension.Configuration = Configuration;
            services.AddMassTransitConfiguration();

            //Add infrastructure layer
            services.AddInfrastructure(Configuration);

            //Add application layer
            services.AddApplication();

            //Add swagger
            services.ConfigureSwagger();

            //Configure Mapper
            services.ConfigureMapping();

            //Add FluentValidation
            services.AddTransient<IValidator<OrderCreateRequestModel>, OrderValidator>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCustomHealthCheck();

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
