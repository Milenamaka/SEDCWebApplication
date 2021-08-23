using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEDCWebApplication.Models.IRepository
{
    public interface ICustomerRepository
    {
        List<Customer> GetAllCustomers();
        Customer GetById(int id);

        Customer Add(Customer customer);
    }
}
