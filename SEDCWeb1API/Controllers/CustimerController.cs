using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SEDCWeb1API.IRepository;
using SEDCWebApplication.BLL.logic.Models;

namespace SEDCWeb1API.Controllers
{
    [Route("api/customer")]
    [ApiController]
    public class CustimerController : Controller
    {

        private readonly ICustomerRepository _customerRepository;
        private readonly IWebHostEnvironment _hostingEnvironment;

        //private List<Employee> employees;

        public CustimerController(ICustomerRepository customerRepository, IWebHostEnvironment hostingEnvironment)
        {
            _customerRepository = customerRepository;
            _hostingEnvironment = hostingEnvironment;

        }



        [Route("all")]
        [HttpGet]
        public IEnumerable<CustomerDTO> Get()
        {
            return _customerRepository.GetAllCustomers();
        }


        [Route("{id}")]
        [HttpGet]
        public CustomerDTO GetById(int id)
        {
            return _customerRepository.GetById(id);
        }


        [HttpPost]
        public CustomerDTO Post([FromBody] CustomerDTO newCustomer)
        {
            CustomerDTO customer = new CustomerDTO {
                Name = newCustomer.Name,
                Address = newCustomer.Address,
                Email = newCustomer.Email,
                ImagePath = newCustomer.ImagePath
            };
            return _customerRepository.Add(customer);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

       
    }
}
