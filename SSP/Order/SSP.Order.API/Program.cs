using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SSP.Order.API.Extensions;
using System;
using System.IO;

namespace SSP.Order.API
{
    public class Program
    {
        private static IConfiguration Configuration
        {
            get
            {
                string env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

                return new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", optional: false)
                    .AddJsonFile($"appsettings.{env}.json", optional: true)
                    .AddEnvironmentVariables()
                    .Build();
            }
        }
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build()
                                   .MigrateDatabase()
                                   .Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureLogging(conf =>
                {
                    conf.ClearProviders();
                    conf.AddDebug();
                    conf.AddConsole();

                })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseConfiguration(Configuration);
                    webBuilder.UseStartup<Startup>();
                });
    }
}
