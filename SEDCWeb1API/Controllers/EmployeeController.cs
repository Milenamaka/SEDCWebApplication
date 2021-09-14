using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using SEDCWeb1API.IRepository;
using SEDCWebApplication.BLL.logic.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SEDCWeb1API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IWebHostEnvironment _hostingEnvironment;

        //private List<Employee> employees;

        public EmployeeController(IEmployeeRepository employeeRepository, IWebHostEnvironment hostingEnvironment)
        {
            _employeeRepository = employeeRepository;
            _hostingEnvironment = hostingEnvironment;
            //MockEmployeeRepository mockEmployeeRepository = new MockEmployeeRepository();
            //employees = mockEmployeeRepository.GetAllEmployees().ToList();
        }

        // GET: api/<EmployeeController>
      

        [HttpGet]
        public IEnumerable<EmployeeDTO> Get()
        {
            return _employeeRepository.GetAllEmployees();
        }


        [HttpGet("{id}")]
        public EmployeeDTO Get(int id)
        {
            return _employeeRepository.GetEmployeeById(id);
        }

        // POST api/<EmployeeController>
        [HttpPost]
        public EmployeeDTO Post([FromBody] EmployeeDTO employee)
        {
            return _employeeRepository.Add(employee);
        }

        // PUT api/<EmployeeController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<EmployeeController>/5
        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            _employeeRepository.Delete(_employeeRepository.GetEmployeeById(id));

            return "Proizvod je obrisan!";
        }
    }
}
