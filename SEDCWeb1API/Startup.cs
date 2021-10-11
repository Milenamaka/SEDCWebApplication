using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SEDCWeb1API.Service.Interfaces;
using SEDCWeb1API.Service.Implementations;
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
using SEDCWeb1API.MIddlewares;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using AutoMapper;
using SEDCWebApplication.BLL.logic;

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
          services.AddControllers(options => {
                var jsonInputFormatter = options.InputFormatters
                .OfType<Microsoft.AspNetCore.Mvc.Formatters.SystemTextJsonInputFormatter>()
                .Last();
                jsonInputFormatter.SupportedMediaTypes.Add("application/csp-report");
                jsonInputFormatter.SupportedMediaTypes.Add("application/json");
            });

          services.AddControllers().AddNewtonsoftJson(x => x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
          services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("SEDC2")));

          var key = Encoding.ASCII.GetBytes(Configuration.GetSection("AppSettings")["Secret"]);

          services.AddAuthentication(x => {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
          })
          .AddJwtBearer(x => {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });
            services.AddCors(options => options.AddPolicy("mypolicy",
                    buoder => {
                        buoder.AllowAnyOrigin();
                        buoder.AllowAnyMethod();
                        buoder.AllowAnyHeader();
                    }));



            //BLL
            services.AddAutoMapper(typeof(ProductManager));

            services.AddSingleton(provider => new MapperConfiguration(cfg => {
                cfg.AddProfile(new AutoMapperProfile(provider.GetService<IConfiguration>()));
            }).CreateMapper());


            services.AddScoped<IProductManager, ProductManager>();
            services.AddScoped<IEmployeeManager, EmployeeManager>();
            services.AddScoped<ICustomerManager, CustomerManager>();
            services.AddScoped<IOrderManager, OrderManager>();
            services.AddScoped<IOrderItemManager, OrderItemManager>();
            services.AddScoped<IUserManager, UserManager>();


            //API
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IOrderItemService, OrderItemService>();
            services.AddScoped<IUserService, UserService>();

            //DAL
            //services.AddScoped<IProductDAL, ProductRepository>();
            //services.AddScoped<IEmployeeDAL, EmployeeRepository>();
            //services.AddScoped<IOrderDAL, OrderRepository>();
            //services.AddScoped<ICustomerDAL, CustomerRepository>();

            //Database
            services.AddScoped<IProductDAL, ProductRepository>();
            services.AddScoped<IEmployeeDAL, EmployeeRepository>();
            services.AddScoped<IOrderDAL, OrderRepository>();
            services.AddScoped<IOrderItemDAL, OrderItemRepository>();
            services.AddScoped<ICustomerDAL, CustomerRepository>();
            services.AddScoped<IUserDAL, UserRepository>();


            services.AddSwaggerGen(c => {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "SEDC Web 1 API", Version = "v1" });

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme {
                    Description = "JWT Authorization header using the Bearer scheme (Example: 'Bearer 12345abcdef')",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = "Bearer"
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        Array.Empty<string>()
                    }
                });


            });

      
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

            app.UseCors();

            app.UseAuthentication();
            app.UseAuthorization();
           
            //custom jwt middleware
            app.UseMiddleware<JwtMiddleware>();


            app.UseMiddleware<ErrorHandlingMiddleware>();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "SEDC Web 1 API v1"));
        }
    }
}
