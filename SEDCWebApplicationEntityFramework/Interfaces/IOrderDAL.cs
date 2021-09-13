using SEDCWebApplicationEntityFactory.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SEDCWebApplicationEntityFactory.Interfaces
{
    public interface IOrderDAL
    {
        void Save(Order item);

        Order GetById(int id);
        List<Order> GetByEmployeeId(int id);

        List<Order> GetAll(int skip, int take);
    }
}
