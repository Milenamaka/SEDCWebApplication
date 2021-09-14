using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SEDCWebApplication.DAL.DatabaseFactory.Entities;
using SEDCWebApplication.DAL.DatabaseFactory.Interfaces;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;

namespace SEDCWebApplication.DAL.DatabaseFactory.Implementations
{
    public class CustomerRepository : ICustomerDAL
    {
        private IConfiguration Configuration {get; set;}
        public CustomerRepository(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public List<Customer> GetAll(int skip, int take)
        {
            var optionBuilder = new DbContextOptionsBuilder<ApplicationDbContext>().UseSqlServer(Configuration.GetConnectionString("SEDC2"));
            using (var db = new ApplicationDbContext(optionBuilder.Options))
            {
                List<Customer> result = db.Customers.Skip(skip).Take(take).ToList();
                return result;
            }
        }

        public Customer GetById(int id)
        {
            var optionBuilder = new DbContextOptionsBuilder<ApplicationDbContext>().UseSqlServer(Configuration.GetConnectionString("SEDC2"));
            using (var db = new ApplicationDbContext(optionBuilder.Options))
            {
                Customer result = db.Customers.First(e => e.Id == id);
                return result;
            }
        }

        public void Save(Customer item)
        {
            var optionBuilder = new DbContextOptionsBuilder<ApplicationDbContext>().UseSqlServer(Configuration.GetConnectionString("SEDC2"));
            using (var db = new ApplicationDbContext(optionBuilder.Options))
            {

                User user = new User();
                user.Password = item.Password;
                user.UserName = item.UserName;
                user.Id = item.Id;

                db.Users.Add(user);
                db.Customers.Add(item);
                db.SaveChanges();
            }
        }

        public void Delete(Customer item)
        {
            var optionBuilder = new DbContextOptionsBuilder<ApplicationDbContext>().UseSqlServer(Configuration.GetConnectionString("SEDC2"));
            using (var db = new ApplicationDbContext(optionBuilder.Options)) {
                db.Customers.Remove(item);
                User user = db.Customers.First(e => e.Id == item.Id);
                db.Users.Remove(user);
                db.SaveChanges();
            }
        }
    }
}
