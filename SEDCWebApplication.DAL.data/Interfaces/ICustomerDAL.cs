using System;
using System.Collections.Generic;
using System.Text;
using SEDCWebApplication.DAL.data.Entities;

namespace SEDCWebApplication.DAL.data.Interfaces
{
    public interface ICustomerDAL
    {
        List<Customer> GetAll(int skip, int take);
        Customer GetById(int id);

        void Save(Customer item);
    }
}
