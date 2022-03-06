using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace SSP.Order.API.Extensions
{
    public static class SwaggerExtension
    {
        public static IServiceCollection ConfigureSwagger(this IServiceCollection service)
        {
            service.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "SSP.Order.API", Version = "v1" });
            });

            return service;
        }
    }
}
