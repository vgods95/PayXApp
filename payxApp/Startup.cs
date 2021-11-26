using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using PayxApp.Models;
using PayxApp.Extensions;
using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;

namespace PayxApp
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
            services.AddDbContext<Context>(options => options.UseMySql(Configuration["ConnectionStrings:Default"]));
            services.AddIdentity<Usuario, Funcao>().AddEntityFrameworkStores<Context>().AddDefaultTokenProviders();

            services.AddDistributedMemoryCache();
            services.ConfigurarCookies();

            services.ConfigurarUsuario();
            services.ConfigurarSenhaUsuario();
            services.AddAuthentication();
            services.AddAuthorization();

            services.AddControllersWithViews().AddRazorRuntimeCompilation();
            services.AddControllersWithViews().AddSessionStateTempDataProvider();
            services.AddRazorPages().AddSessionStateTempDataProvider();

            services.AddSession(options =>
            {
                options.Cookie.Name = "CookieSessao";
                options.IdleTimeout = TimeSpan.FromDays(15);
                options.Cookie.IsEssential = true;
            });

            services.Configure<CookieTempDataProviderOptions>(options =>
            {
                options.Cookie.IsEssential = true;
            });


            services.AddControllersWithViews();
            services.ConfigurarRepositorios();
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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseSession();
            app.UseCookiePolicy();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}");
            });
        }
    }
}
