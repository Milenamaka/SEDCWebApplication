using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using SEDCWebApplicationEntityFactory.Entities;
using SEDCWebApplicationEntityFactory.Interfaces;

namespace SEDCWebApplicationEntityFactory.Implementations
{
    public class CustomerRepository : ICustomerDAL
    {
        public List<Customer> GetAll(int skip, int take)
        {
            using (var db = new PizzaShop1Context()) {
                List<Customer> result = db.Customers.Skip(skip).Take(take).ToList();
                return result;
            }
        }

        public Customer GetById(int id)
        {
            using (var db = new PizzaShop1Context()) {
                Customer result = db.Customers.First(e => e.CustomerId == id);
                return result;
            }
        }

        public void Save(Customer item)
        {
            using (var db = new PizzaShop1Context()) {
                User user = new User();
                user.Customer = item;
                db.Users.Add(user);
                db.SaveChanges();
            }
        }
    }
}
