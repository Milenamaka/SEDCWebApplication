using System.Collections.Generic;
using SEDCWebApplication.BLL.logic.Models;


namespace SEDCWeb1API.Service.Interfaces
{ 
public interface ICustomerService
    {
        IEnumerable<CustomerDTO> GetAllCustomers();
        CustomerDTO GetById(int id);

        CustomerDTO Add(CustomerDTO customer);

        CustomerDTO Delete(CustomerDTO customer);
    }
}
