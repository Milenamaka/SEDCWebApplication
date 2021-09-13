using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SEDCWeb1API.IRepository;
using SEDCWeb1API.RepositoryImpl;
using SEDCWebApplication.BLL.logic.Implementations;
using SEDCWebApplication.BLL.logic.Interfaces;
//using SEDCWebApplication.DAL.data.Implementations;
//using SEDCWebApplication.DAL.data.Interfaces;
using SEDCWebApplicationEntityFactory.Interfaces;
using SEDCWebApplicationEntityFactory.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEDCWeb1API
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
            services.AddControllers();
            services.AddAutoMapper(typeof(ProductManager));
            services.AddScoped<IProductManager, ProductManager>();
            services.AddScoped<IEmployeeManager, EmployeeManager>();
            services.AddScoped<ICustomerManager, CustomerManager>();
            
            services.AddScoped<IProductRepository, DatabaseProductRepository>();
            services.AddScoped<ICustomerRepository, DatabaseCustomerRepository>();
            services.AddScoped<IEmployeeRepository, DatabaseEmployeeRepository>();


            services.AddScoped<IProductDAL, ProductRepository>();
            services.AddScoped<IEmployeeDAL, EmployeeRepository>();
            services.AddScoped<IOrderDAL, OrderRepository>();
            services.AddScoped<ICustomerDAL, CustomerRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
