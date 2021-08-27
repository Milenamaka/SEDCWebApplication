using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SEDCWebApplication.BLL.logic.Interfaces;
using SEDCWebApplication.BLL.logic.Models;
using SEDCWebApplication.Models.IRepository;

namespace SEDCWebApplication.Models.RepositoryImpl
{
    public class DatabaseCustomerRepository : ICustomerRepository
    {
        private readonly ICustomerManager _customerManager;
        public DatabaseCustomerRepository(ICustomerManager customerManager)
        {
            _customerManager = customerManager;
        }
        public IEnumerable<CustomerDTO> GetAllCustomers()
        {
            return _customerManager.GetAllCustomers();
        }

        public CustomerDTO GetById(int id)
        {
            return _customerManager.GetCustomerById(id);
        }

        public CustomerDTO Add(CustomerDTO customer)
        {
            return _customerManager.Add(customer);
        }
    }
}

