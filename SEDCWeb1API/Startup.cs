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
//using SEDCWebApplicationEntityFactory.Interfaces;
//using SEDCWebApplicationEntityFactory.Implementations;
using SEDCWebApplication.DAL.DatabaseFactory.Entities;
using SEDCWebApplication.DAL.DatabaseFactory.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using SEDCWebApplication.DAL.DatabaseFactory;
using SEDCWebApplication.DAL.DatabaseFactory.Implementations;

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
            
            services.AddControllers().AddNewtonsoftJson(x => x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("SEDC2")));

            services.AddAutoMapper(typeof(ProductManager));
            services.AddScoped<IProductManager, ProductManager>();
            services.AddScoped<IEmployeeManager, EmployeeManager>();
            services.AddScoped<ICustomerManager, CustomerManager>();
            
            services.AddScoped<IProductRepository, DatabaseProductRepository>();
            services.AddScoped<ICustomerRepository, DatabaseCustomerRepository>();
            services.AddScoped<IEmployeeRepository, DatabaseEmployeeRepository>();

            //DALL
            //services.AddScoped<IProductDAL, ProductRepository>();
            //services.AddScoped<IEmployeeDAL, EmployeeRepository>();
            //services.AddScoped<IOrderDAL, OrderRepository>();
            //services.AddScoped<ICustomerDAL, CustomerRepository>();


            services.AddScoped<IProductDAL, ProductRepository>();
            services.AddScoped<IEmployeeDAL, EmployeeRepository>();
            services.AddScoped<IOrderDAL, OrderRepository>();
            services.AddScoped<ICustomerDAL, CustomerRepository>();

            services.AddSwaggerGen(c => {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "SEDC Web 1 API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "SEDC Web 1 API v1"));
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
