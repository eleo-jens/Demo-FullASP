using BLLObject = Demo_BLL.Entities;
using DALObject = Demo_DAL.Entities;
using BLLServ = Demo_BLL.Services;
using DALServ = Demo_DAL.Services;
using Demo_Common.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo_ASP
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
            services.AddControllersWithViews();
            services.AddScoped<IClientRepository<BLLObject.Client, int>, BLLServ.ClientService>();
            services.AddScoped<IClientRepository<DALObject.Client, int>, DALServ.ClientService>();
            services.AddScoped<ISpectacleRepository<BLLObject.Spectacle, int>, BLLServ.SpectacleService>();
            services.AddScoped<ISpectacleRepository<DALObject.Spectacle, int>, DALServ.SpectacleService>();
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
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
