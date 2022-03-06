using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace SSP.Order.API.Extensions
{
    public static class HealthCheckConfigureExtension
    {
        public static IApplicationBuilder UseCustomHealthCheck(this IApplicationBuilder app)
        {
            //For api healthcheck
            app.UseHealthChecks("/api/health", new Microsoft.AspNetCore.Diagnostics.HealthChecks.HealthCheckOptions()
            {
                ResponseWriter = async (context, report) =>
                {
                    await context.Response.WriteAsync("OK");
                }
            });

            return app;
        }
    }
}
