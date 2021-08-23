using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SEDCWebApplication.Models.IRepository;

namespace SEDCWebApplication.Models.RepositoryImpl
{
    public class MockCustomerRepository : ICustomerRepository
    {
        private List<Customer> _customerList;
        public MockCustomerRepository()
        {
            _customerList = new List<Customer>()
            {
                 new Customer
                {
                    Id=1,
                    Name="Maja",
                    Address="Njegoseva 55",
                    ContactId= 6,
                    Email ="maja@gmail.com"
                },
                new Customer
                {
                    Id=2,
                    Name="Milan",
                    Address="Mokranjceva 26",
                    ContactId= 7,
                    Email ="milan@gmail.com"
                },
                new Customer
                {
                    Id=3,
                    Name="Luka",
                    Address="Kotorska 11",
                    ContactId= 5,
                    Email ="luka@gmail.com"
                }
            };
           
        }
        public List<Customer> GetAllCustomers()
        {
            return _customerList;
        }

        public Customer GetById(int id)
        {
            return _customerList.Where(x => x.Id == id).FirstOrDefault();
        }

        public Customer Add(Customer customer)
        {
            customer.Id = _customerList.Max(e => e.Id) + 1;
            _customerList.Add(customer);
            return _customerList.Where(x => x.Id == customer.Id).FirstOrDefault();
        }

    }
}

