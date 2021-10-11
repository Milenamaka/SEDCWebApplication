using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using SEDCWebApplication.DAL.DatabaseFactory.Entities;

namespace SEDCWebApplication.DAL.DatabaseFactory
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<User> Users { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasData(
                new Employee {
                    Id = 5,
                    Name = "Marko",
                    Gender = "M",
                    Password = "markovic",
                    RoleId = 1,
                    UserName = "marko"
                }
            );
        }

    }
}
