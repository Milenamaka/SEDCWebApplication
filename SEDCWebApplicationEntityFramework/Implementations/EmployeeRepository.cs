using SEDCWebApplicationEntityFactory.Entities;
using SEDCWebApplicationEntityFactory.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SEDCWebApplicationEntityFactory.Implementations
{
    public class EmployeeRepository : IEmployeeDAL
    {
        public List<Employee> GetAll(int skip, int take)
        {
            using(var db = new PizzaShop1Context())
            {
                List<Employee> result = db.Employees.Skip(skip).Take(take).ToList();
                return result;
            }
        }

        public Employee GetById(int id)
        {
            using (var db = new PizzaShop1Context())
            {
                Employee result = db.Employees.First(e => e.EmployeeId == id);
                return result;
            }
        }

        public void Save(Employee item)
        {
            using (var db = new PizzaShop1Context())
            {
                User user = new User();
                user.Employee = item;
                db.Users.Add(user);
                db.SaveChanges();
            }
        }
    }
}
