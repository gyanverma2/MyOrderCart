using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MyOrderCart.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MudBlazor.Services;
using MyOrderCart.Services;
using Microsoft.AspNetCore.ProtectedBrowserStorage;
using Microsoft.EntityFrameworkCore;
using Microsoft.DotNet.PlatformAbstractions;
namespace MyOrderCart
{
public class Startup
{
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddMudServices();
            services.AddHttpClient();
            services.AddProtectedBrowserStorage();
            services.AddSingleton<WeatherForecastService>();
            services.AddDbContextFactory<OrderContext>(opt => opt.UseSqlite($"Data Source={nameof(OrderContext.OrderDb)}.db"));
            services.AddSingleton<IFakeApiService, FakeApiService>();
            services.AddHttpClient<IFakeApiService, FakeApiService>(c =>
            {
                c.BaseAddress = new Uri(Configuration.GetValue<string>("APIUrl:FakeAPI"));
            });
            services.AddDbContextFactory<InMemoryContext>(options => options.UseInMemoryDatabase(databaseName: "InMemoryDB"));
            services.AddSingleton<IDummyRequestAPI, DummyRequestAPI>();
            services.AddHttpClient<IDummyRequestAPI, DummyRequestAPI>(c =>
            {
                c.BaseAddress = new Uri(Configuration.GetValue<string>("APIUrl:DummyRequestAPI"));
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}
