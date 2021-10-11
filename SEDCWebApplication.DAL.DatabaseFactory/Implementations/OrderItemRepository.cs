using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SEDCWebApplication.DAL.DatabaseFactory.Entities;
using SEDCWebApplication.DAL.DatabaseFactory.Interfaces;


namespace SEDCWebApplication.DAL.DatabaseFactory.Implementations
{
    public class OrderItemRepository : IOrderItemDAL
    {

        private IConfiguration Configuration { get; set; }
        public OrderItemRepository(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public List<OrderItem> GetAll(int skip, int take)
        {
            var optionBuilder = new DbContextOptionsBuilder<ApplicationDbContext>().UseSqlServer(Configuration.GetConnectionString("SEDC2"));
            using (var db = new ApplicationDbContext(optionBuilder.Options)) {

                List<OrderItem> result = db.OrderItems.Skip(skip).Take(take).ToList();
                return result;

            }
        }


        public OrderItem GetById(int id)
        {
            var optionBuilder = new DbContextOptionsBuilder<ApplicationDbContext>().UseSqlServer(Configuration.GetConnectionString("SEDC2"));
            using (var db = new ApplicationDbContext(optionBuilder.Options)) {

                OrderItem result = db.OrderItems.First(e => e.OrderItemId == id);
                return result;

            }
        }

        public void Save(OrderItem item)
        {
            var optionBuilder = new DbContextOptionsBuilder<ApplicationDbContext>().UseSqlServer(Configuration.GetConnectionString("SEDC2"));
            using (var db = new ApplicationDbContext(optionBuilder.Options)) {
                db.OrderItems.Add(item);
                db.SaveChanges();
            }
        }

        public void Delete(OrderItem item)
        {
            var optionBuilder = new DbContextOptionsBuilder<ApplicationDbContext>().UseSqlServer(Configuration.GetConnectionString("SEDC2"));
            using (var db = new ApplicationDbContext(optionBuilder.Options)) {
                db.OrderItems.Remove(item);
                db.SaveChanges();
            }
        }
    }
}
