using System;
using System.Collections.Generic;
using System.Text;
using SEDCWebApplication.BLL.logic.Models;

namespace SEDCWebApplication.BLL.logic.Interfaces
{
    public interface ICustomerManager
    {
        IEnumerable<CustomerDTO> GetAllCustomers();
        CustomerDTO GetCustomerById(int id);

        CustomerDTO Add(CustomerDTO customer);
    }
}
