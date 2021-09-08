using AutoMapper;
using SEDCWebApplication.BLL.logic.Models;
using SEDCWebApplication.DAL.data.Entities;
using System;

namespace SEDCWebApplication.BLL.Logic
{
    public class AutoMapperProfile : Profile
    {

        public AutoMapperProfile()
        {
            CreateMap<Employee, EmployeeDTO>();

            CreateMap<EmployeeDTO, Employee>()
                .ForMember(dest => dest.UserName, src => src.MapFrom(src => src.Email))
                    .ForMember(dest => dest.RoleId, src => src.MapFrom(src => src.Role));


            CreateMap<Customer, CustomerDTO>();

            CreateMap<CustomerDTO, Customer>();


            CreateMap<Product, ProductDTO>();

            CreateMap<ProductDTO, Product>();

        }
    }
}
