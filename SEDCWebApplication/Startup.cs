using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SEDCWebApplication.BLL.Logic.Implementations;
using SEDCWebApplication.BLL.Logic.Interfaces;
using SEDCWebApplication.DAL.Data.Implementations;
using SEDCWebApplication.DAL.Data.Interfaces;
using SEDCWebApplication.Models.Repositories.Implementations;
using SEDCWebApplication.Models.Repositories.Interfaces;

namespace SEDCWebApplication
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

            services.AddAutoMapper(typeof(EmployeeManager));

            services.AddScoped<IEmployeeRepository, DatabaseEmployeeRepository>();


            //BLL
            services.AddScoped<IEmployeeManager, EmployeeManager>();

            //DAL
            services.AddScoped<IEmployeeDAL, EmployeeDAL>();
            services.AddScoped<IOrderDAL, OrderDAL>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILogger<Startup> logger)
        {
            if (env.IsDevelopment())
            {
                app.UseStatusCodePagesWithRedirects("/ErrorStatus/{0}");
                //app.UseExceptionHandler("/Error");
                //app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("Hello from Middleware!");
            //});

            app.Use(async (context, next) =>
            {
                logger.LogInformation("Middelware 1 Request In");
                //await context.Response.WriteAsync("Hello from Middleware!");
                await next();

                logger.LogInformation("Middelware 1 Response Out");
            });

            app.UseHttpsRedirection();
            app.UseStaticFiles();


            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                    name: "demo",
                    pattern: "Demo/{id}",
                    defaults: new { controller = "Home", action = "Privacy" });

                endpoints.MapControllerRoute(
                    name: "test",
                    pattern: "Test/{id}/{*name}",//Test/1/12/3
                    defaults: new { controller = "Home", action = "Privacy" });
            });
        }
    }
}
