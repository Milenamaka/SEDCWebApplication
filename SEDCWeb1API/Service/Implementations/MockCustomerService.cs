using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SEDCWeb1API.Service.Interfaces;
using SEDCWebApplication.BLL.logic.Models;



namespace SEDCWeb1API.RepositoryImpl
{
    public class MockCustomerService : ICustomerService
    {
        private List<CustomerDTO> _customerList;
        public MockCustomerService()
        {
            _customerList = new List<CustomerDTO>()
            {
                 new CustomerDTO
                {
                    Id=1,
                    Name="Maja",
                    Address="Njegoseva 55",
                    //ContactId= 6,
                    Email ="maja@gmail.com"
                },
                new CustomerDTO
                {
                    Id=2,
                    Name="Milan",
                    Address="Mokranjceva 26",
                    //ContactId= 7,
                    Email ="milan@gmail.com"
                },
                new CustomerDTO
                {
                    Id=3,
                    Name="Luka",
                    Address="Kotorska 11",
                    //ContactId= 5,
                    Email ="luka@gmail.com"
                }
            };
           
        }
        public IEnumerable<CustomerDTO> GetAllCustomers()
        {
            return _customerList;
        }

        public CustomerDTO GetById(int id)
        {
            return _customerList.Where(x => x.Id == id).FirstOrDefault();
        }

        public CustomerDTO Add(CustomerDTO customer)
        {
            customer.Id = _customerList.Max(e => e.Id) + 1;
            _customerList.Add(customer);
            return _customerList.Where(x => x.Id == customer.Id).FirstOrDefault();
        }

        public CustomerDTO Delete(CustomerDTO customer)
        {
            throw new NotImplementedException();
        }
    }
}

