using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using SSP.Order.API.Mapper;
using System.Reflection;

namespace SSP.Order.API.Extensions
{
    public static class ConfigureMappingProfileExtension
    {
        public static IServiceCollection ConfigureMapping(this IServiceCollection service)
        {
            service.AddAutoMapper(Assembly.GetExecutingAssembly());
            var config = new MapperConfiguration(cfg =>
            {
                cfg.ShouldMapProperty = p => p.GetMethod.IsPublic || p.GetMethod.IsAssembly;
                cfg.AddProfile<OrderMappingProfile>();
            });

            return service;
        }
    }

}
