using BLLObject = Demo_BLL.Entities;
using DALObject = Demo_DAL.Entities;
using BLLServ = Demo_BLL.Services;
using DALServ = Demo_DAL.Services;
using Demo_Common.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Demo_ASP.Handlers;

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
            // on utiliser les services dans les controlleurs
            services.AddControllersWithViews();
            //service d'accessibilité du HttpContext par injection de dépendances
            services.AddHttpContextAccessor();
            
            #region Création de cookie de session
            services.AddDistributedMemoryCache();
            services.AddSession(options =>
            {
                options.Cookie.Name = "Theatre.Session";
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
                options.IdleTimeout = TimeSpan.FromMinutes(50);
            });
            services.Configure<CookiePolicyOptions>(options => {
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
                options.Secure = CookieSecurePolicy.Always; 
            });
            #endregion

            #region Injection de dépendances
            //Appel du sessionManager par injection de dépendance
            services.AddScoped<SessionManager>();
            // on risque de me demander un IClientRepository<BLLObject.Client, int>, on aura un BLLServ.ClientService
            services.AddScoped<IClientRepository<BLLObject.Client, int>, BLLServ.ClientService>();
            services.AddScoped<IClientRepository<DALObject.Client, int>, DALServ.ClientService>();
            services.AddScoped<ISpectacleRepository<BLLObject.Spectacle, int>, BLLServ.SpectacleService>();
            services.AddScoped<ISpectacleRepository<DALObject.Spectacle, int>, DALServ.SpectacleService>(); 
            #endregion
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
            //à toujours mettre avant le app.UseHttpsRedirection()
            app.UseSession();
            app.UseCookiePolicy();

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
