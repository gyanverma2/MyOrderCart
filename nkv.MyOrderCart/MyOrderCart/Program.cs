using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MyOrderCart.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyOrderCart
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            var sp = host.Services.GetService<IServiceScopeFactory>()
              .CreateScope()
              .ServiceProvider;
            var options = sp.GetRequiredService<DbContextOptions<OrderContext>>();
            EnsureDbCreatedAsync(options, 500);
            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
        private static void EnsureDbCreatedAsync(DbContextOptions<OrderContext> options, int count)
        {
            // empty to avoid logging while inserting (otherwise will flood console)
            var factory = new LoggerFactory();
            var builder = new DbContextOptionsBuilder<OrderContext>(options)
                .UseLoggerFactory(factory);

            using var context = new OrderContext(builder.Options);
            context.Database.EnsureCreatedAsync();
        }
    }
}
