using Microsoft.EntityFrameworkCore;
using SEDCWebApplicationEntityFactory.Entities;
using SEDCWebApplicationEntityFactory.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SEDCWebApplicationEntityFactory.Implementations
{
    public class OrderRepository : IOrderDAL
    {
        public List<Order> GetAll(int skip, int take)
        {
            throw new NotImplementedException();
        }

        public List<Order> GetByEmployeeId(int id)
        {
            using (var db = new PizzaShop1Context())
            {
                List<Order> result = db.Orders
                    .Include(o => o.Customer).Where(e => e.EmployeeId == id).ToList();
                return result;
            }
        }

        public Order GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Save(Order item)
        {
            throw new NotImplementedException();
        }
    }
}
