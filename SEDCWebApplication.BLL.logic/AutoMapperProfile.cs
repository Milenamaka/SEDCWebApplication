using AutoMapper;
using SEDCWebApplication.BLL.logic.Models;
//using SEDCWebApplicationEntityFactory.Entities;
using SEDCWebApplication.DAL.DatabaseFactory.Entities;
using SEDCWebApplication.DAL.data.Entities;
using System;
using SEDCWebApplication.BLL.logic.Helpers;
using Microsoft.Extensions.Configuration;


namespace SEDCWebApplication.BLL.logic
{
    public class AutoMapperProfile : Profile
    {

        public AutoMapperProfile(IConfiguration configuration)
        {
          
            CreateMap<DAL.data.Entities.Employee, EmployeeDTO>();

            CreateMap<EmployeeDTO, DAL.data.Entities.Employee>()
                .ForMember(dest => dest.UserName, src => src.MapFrom(src => src.Email))
                    .ForMember(dest => dest.RoleId, src => src.MapFrom(src => src.Role));


            CreateMap<SEDCWebApplicationEntityFactory.Entities.Employee, EmployeeDTO>()
                .ForMember(dest => dest.Id, src => src.MapFrom(src => src.EmployeeId))
                .ForMember(dest => dest.Role, src => src.MapFrom(src => src.RoleId))
                 .ForMember(dest => dest.Name, src => src.MapFrom(src => src.EmployeeName));

            CreateMap<EmployeeDTO, SEDCWebApplicationEntityFactory.Entities.Employee>()
                 .ForMember(dest => dest.EmployeeId, src => src.MapFrom(src => src.Id))
                .ForMember(dest => dest.EmployeeName, src => src.MapFrom(src => src.Email))
                    .ForMember(dest => dest.RoleId, src => src.MapFrom(src => src.Role))
                        .ForMember(dest => dest.Role, src => src.Ignore());



            CreateMap<DAL.data.Entities.Customer, CustomerDTO>();

            CreateMap<CustomerDTO, DAL.data.Entities.Customer>();


            CreateMap<SEDCWebApplicationEntityFactory.Entities.Customer, CustomerDTO>()
                .ForMember(dest => dest.Id, src => src.MapFrom(src => src.CustomerId))
                 .ForMember(dest => dest.Name, src => src.MapFrom(src => src.CustomerName));

            CreateMap<CustomerDTO, SEDCWebApplicationEntityFactory.Entities.Customer>()
                .ForMember(dest => dest.CustomerName, src => src.MapFrom(src => src.Name))
                    .ForMember(dest => dest.CustomerId, src => src.MapFrom(src => src.Id));


            CreateMap<DAL.data.Entities.Product, ProductDTO>();

            CreateMap<ProductDTO, DAL.data.Entities.Product>();


            CreateMap<SEDCWebApplicationEntityFactory.Entities.Product, ProductDTO>()
                .ForMember(dest => dest.Id, src => src.MapFrom(src => src.ProductId));


            CreateMap<ProductDTO, SEDCWebApplicationEntityFactory.Entities.Product>()
                .ForMember(dest => dest.ProductId, src => src.MapFrom(src => src.Id));



            CreateMap<DAL.DatabaseFactory.Entities.Employee, EmployeeDTO>();

            CreateMap<EmployeeDTO, DAL.DatabaseFactory.Entities.Employee >()
                    .ForMember(dest => dest.RoleId, src => src.MapFrom(src => src.Role));

            CreateMap<DAL.DatabaseFactory.Entities.Customer, CustomerDTO>();
        
            CreateMap<CustomerDTO, DAL.DatabaseFactory.Entities.Customer>();


            CreateMap<DAL.DatabaseFactory.Entities.Product, ProductDTO>();

            CreateMap<ProductDTO, DAL.DatabaseFactory.Entities.Product>();

            CreateMap<DAL.DatabaseFactory.Entities.Order, OrderDTO>();

            CreateMap<OrderDTO, DAL.DatabaseFactory.Entities.Order>();


            CreateMap<DAL.DatabaseFactory.Entities.OrderItem, OrderItemDTO>();

            CreateMap<OrderItemDTO, DAL.DatabaseFactory.Entities.OrderItem>();

            CreateMap<DAL.DatabaseFactory.Entities.User, UserDTO>();


            CreateMap<DAL.DatabaseFactory.Entities.User, UserDTO>()
                .ForMember(dest => dest.Role, src => src.MapFrom(src => EnumHelper.GetString<RoleEnum>(src.RoleId)));



            CreateMap<DAL.DatabaseFactory.Entities.Employee, EmployeeDTO>()
         .ForMember(dest => dest.Id, src => src.MapFrom(src => src.Id))
         .ForMember(dest => dest.Role, src => src.MapFrom(src => src.RoleId))
         .ForMember(dest => dest.ImagePath, src => src.MapFrom(src => (new ImageHelper(configuration)).GetFullImagePath(src.ImagePath)));

            CreateMap<EmployeeDTO, DAL.DatabaseFactory.Entities.Employee>()
                .ForMember(dest => dest.Name, src => src.MapFrom(src => src.Email))
                    .ForMember(dest => dest.RoleId, src => src.MapFrom(src => src.Role));








        }
    }
}
