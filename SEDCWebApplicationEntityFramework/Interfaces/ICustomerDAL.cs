using System;
using System.Collections.Generic;
using System.Text;
using SEDCWebApplicationEntityFactory.Entities;

namespace SEDCWebApplicationEntityFactory.Interfaces
{

    public interface ICustomerDAL
    {
        List<Customer> GetAll(int skip, int take);
        Customer GetById(int id);

        void Save(Customer item);
    
    }

}
