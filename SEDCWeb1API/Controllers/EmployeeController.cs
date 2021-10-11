using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using SEDCWeb1API.Helpers;
using SEDCWeb1API.Service.Interfaces;
using SEDCWebApplication.BLL.logic.Models;
using Serilog;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SEDCWeb1API.Controllers
{
    [EnableCors("nyolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly ILogger _logger;

        //private List<Employee> employees;

        public EmployeeController(IEmployeeService employeeRepository, ILogger logger, IWebHostEnvironment hostingEnvironment)
        {
            _employeeService = employeeRepository;
            _hostingEnvironment = hostingEnvironment;
            _logger = logger;
            //MockEmployeeRepository mockEmployeeRepository = new MockEmployeeRepository();
            //employees = mockEmployeeRepository.GetAllEmployees().ToList();
        }

        // GET: api/<EmployeeController>

        [Authorize(Roles = AuthorizationRoles.Admin)] 
        [HttpGet]
        public ActionResult<IEnumerable<EmployeeDTO>> Get()
        {
            return Ok( _employeeService.GetAllEmployees());
        }

       
        [HttpGet("{id}")]
        public ActionResult<EmployeeDTO> GetById(int id)
        {
            return Ok(_employeeService.GetEmployeeById(id));
        }

        // POST api/<EmployeeController>
        [HttpPost]
        public EmployeeDTO Post([FromBody] EmployeeDTO employee)
        {
            return _employeeService.Add(employee);
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
            _employeeService.Delete(_employeeService.GetEmployeeById(id));

            return "Proizvod je obrisan!";
        }
    }
}
