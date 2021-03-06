using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using SEDCWebApplication.BLL.logic.Interfaces;
using SEDCWebApplication.BLL.logic.Models;
//using SEDCWebApplicationEntityFactory.Entities;
//using SEDCWebApplicationEntityFactory.Interfaces;
using SEDCWebApplication.DAL.DatabaseFactory.Entities;
using SEDCWebApplication.DAL.DatabaseFactory.Interfaces;

namespace SEDCWebApplication.BLL.logic.Implementations
{

    public class CustomerManager : ICustomerManager
    {
        private readonly ICustomerDAL _customerDAL;
        private readonly IMapper _mapper;
        public CustomerManager(ICustomerDAL customerDAL, IMapper mapper)
        {
            _customerDAL = customerDAL;
            _mapper = mapper;
        }
        public CustomerDTO Add(CustomerDTO customer)
        {
            Customer customerEntity = _mapper.Map<Customer>(customer);
            _customerDAL.Save(customerEntity);
            customer = _mapper.Map<CustomerDTO>(customerEntity);
            return customer;
        }

        public IEnumerable<CustomerDTO> GetAllCustomers()
        {
            return _mapper.Map<List<CustomerDTO>>(_customerDAL.GetAll(0, 90));
        }

        public CustomerDTO GetCustomerById(int id)
        {
            return _mapper.Map<CustomerDTO>(_customerDAL.GetById(id));
        }


        public CustomerDTO Delete(CustomerDTO customer)
        {

            Customer customerEntity = _mapper.Map<Customer>(customer);
            _customerDAL.Delete(customerEntity);
            customer = _mapper.Map<CustomerDTO>(customerEntity);
            return customer;
        }
    }
}
