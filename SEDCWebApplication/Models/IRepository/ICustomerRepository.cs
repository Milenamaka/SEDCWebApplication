using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SEDCWebApplication.BLL.logic.Models;

namespace SEDCWebApplication.Models.IRepository
{
    public interface ICustomerRepository
    {
        IEnumerable<CustomerDTO> GetAllCustomers();
        CustomerDTO GetById(int id);

        CustomerDTO Add(CustomerDTO customer);
    }
}
