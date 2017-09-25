using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using StoreApp.Models;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using StoreApp.ViewModels;

namespace StoreApp
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddMvc();

            services.AddScoped<IStoreRepository, StoreRepository>();

            services.AddTransient<StoreContextSeedData>();

            services.AddDbContext<StoreContext>(options =>
             options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, StoreContextSeedData seeder, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();
            Mapper.Initialize(config =>
            {
                config.CreateMap<ProductViewModel, Products>().ReverseMap();
                config.CreateMap<CartItemsViewModel, CartItems>().ReverseMap();
            });
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseCookieAuthentication(new CookieAuthenticationOptions()
            {
                AccessDeniedPath = "/Account/Forbidden/",
                AuthenticationScheme = "MyCookieAuthenticationScheme",
                AutomaticAuthenticate = true,
                AutomaticChallenge = true,
                LoginPath = "/Account/Unauthorized/"
            });

            //app.UseMvc(routes =>
            //{
            //    routes.MapRoute(
            //        name: "default",
            //        template: "{controller}/{action=Index}/{id?}");
            //});
            app.UseMvc(config =>
            {
                config.MapRoute(
                  name: "Default",
                  template: "{controller}/{action}/{id?}",
                  defaults: new { controller = "Home", action = "Index" }
                  );
            });
            seeder.EnsureSeedData().Wait();
        }
    }
}
