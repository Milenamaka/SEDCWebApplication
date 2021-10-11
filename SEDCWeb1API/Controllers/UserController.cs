using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SEDCWeb1API.Service.Interfaces;
using SEDCWebApplication.BLL.logic.Models;

namespace SEDCWeb1API.Controllers
{
    [EnableCors("mypolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly IUserService _userService;
        private readonly IWebHostEnvironment _hostingEnvironment;

        //private List<Employee> employees;

        public UserController(IUserService userService, IWebHostEnvironment hostingEnvironment)
        {
            _userService = userService;
            _hostingEnvironment = hostingEnvironment;
            //MockEmployeeRepository mockEmployeeRepository = new MockEmployeeRepository();
            //employees = mockEmployeeRepository.GetAllEmployees().ToList();
        }

        [HttpPost]
        public IActionResult Authenticate([FromBody] AuthenticateDTO authenticateModel)
        {
            UserDTO user = _userService.Authenticate(authenticateModel.UserName, authenticateModel.Password);

            if (user == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(user);

        }

    }
}
