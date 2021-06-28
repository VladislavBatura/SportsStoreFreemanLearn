using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using SportsStore.Models;
using SportsStore.Models.Data;
using SportsStore.Models.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;

namespace SportsStore
{
    public class Startup
    {
        private IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration) => Configuration = configuration;

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(
                options => options.UseSqlServer(
                    Configuration["Data:SportsStoreProducts:connectionString"]));
            services.AddTransient<IProductRepository, EFProductRepository>(); //Даёт возможность временно использовать фейковую бд UPD. Произошла замена
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: null,
                    template: "{category}/Page{productPage:int}",
                    defaults: new {controller = "Product", action = "List"}
                );
                routes.MapRoute(
                    name: null,
                    template: "Page{productPage:int}",
                    defaults: new { Controller = "Product",
                        action = "List", productPage = 1 }
                    );
                routes.MapRoute(
                    name: null,
                    template: "{category}",
                    defaults: new
                    {
                        Controller = "Product",
                        action = "List",
                        productPage = 1
                    }
                );
                routes.MapRoute(
                    name: null,
                    template: "",
                    defaults: new
                    {
                        Controller = "Product",
                        action = "List",
                        productPage = 1
                    }
                );
                routes.MapRoute(
                    name: null,
                    template: "{controller}/{action}/{id?}");
            });
            SeedData.EnsurePopulated(app);
        }
    }
}
