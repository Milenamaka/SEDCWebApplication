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
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : Controller
    {

        private readonly ICustomerRepository _customerRepository;
        private readonly IWebHostEnvironment _hostingEnvironment;

        //private List<Employee> employees;

        public CustomerController(ICustomerRepository customerRepository, IWebHostEnvironment hostingEnvironment)
        {
            _customerRepository = customerRepository;
            _hostingEnvironment = hostingEnvironment;

        }



        [HttpGet]
        public IEnumerable<CustomerDTO> Get()
        {
            return _customerRepository.GetAllCustomers();
        }


        [HttpGet("{id}")]
        public CustomerDTO GetById(int id)
        {
            return _customerRepository.GetById(id);
        }


        [HttpPost]
        public CustomerDTO Post([FromBody] CustomerDTO customer)
        {
           
            return _customerRepository.Add(customer);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }


        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            _customerRepository.Delete(_customerRepository.GetById(id));

            return "Proizvod je obrisan!";
        }

    }
}
