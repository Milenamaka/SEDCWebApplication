using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SEDCWeb1API.Helpers;
using SEDCWeb1API.Service.Interfaces;
using SEDCWebApplication.BLL.logic.Models;

using Serilog;


namespace SEDCWeb1API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : Controller
    {

        private readonly ICustomerService _customerRepository;
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly ILogger _logger;

        //private List<Employee> employees;

        public CustomerController(ICustomerService customerRepository, ILogger logger, IWebHostEnvironment hostingEnvironment)
        {
            _customerRepository = customerRepository;
            _hostingEnvironment = hostingEnvironment;
            _logger = logger;
        }


        [Authorize(Roles = AuthorizationRoles.Admin)]
        [HttpGet]
        public ActionResult<IEnumerable<CustomerDTO>> Get()
        {
            return Ok(_customerRepository.GetAllCustomers());
        }

        [Authorize(Roles = AuthorizationRoles.Admin)]
        [HttpGet("{id}")]
        public ActionResult<CustomerDTO> GetById(int id)
        {
            return Ok(_customerRepository.GetById(id));
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
