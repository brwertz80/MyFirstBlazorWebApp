using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using myWebApp.Models;
using myWebApp.Services;

namespace myWebApp
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
            services.AddRazorPages();
            // Added in ASP.NET Core 101 [8 of 13] (https://youtu.be/VI40Y3kFcNc?t=542)
            services.AddControllers();
            // Added in ASP.NET Core 101 [10 of 13] (https://youtu.be/R23v4lgHYQI?t=597)
            services.AddServerSideBlazor();
            services.AddTransient<JsonFileProductService>();
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
            }

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                // All below added in ASP.NET Core 101 [7 of 13] (https://youtu.be/04IP3Yl8-64?t=207)
                // This is a simple, manual way to create a Web API.
                // Commented out and replaced with Controllers\ProductController.cs
                //endpoints.MapGet("/products",(context) =>
                //{
                //    // This will retrieve all of the products again
                //    var products = app.ApplicationServices.GetService<JsonFileProductService>().GetProducts();
                //    var json = JsonSerializer.Serialize<IEnumerable<Product>>(products);
                //    return context.Response.WriteAsync(json);
                //});
                endpoints.MapControllers();
                // Added in ASP.NET Core 101 [10 of 13] (https://youtu.be/R23v4lgHYQI?t=619)
                endpoints.MapBlazorHub();
            });
        }
    }
}
