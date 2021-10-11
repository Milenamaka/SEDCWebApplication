using SEDCWebApplication.DAL.DatabaseFactory.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SEDCWebApplication.DAL.DatabaseFactory.Interfaces
{
    public interface IOrderItemDAL
    {
        void Save(OrderItem item);

        OrderItem GetById(int id);

        List<OrderItem> GetAll(int skip, int take);

        void Delete(OrderItem item);
    }
}
