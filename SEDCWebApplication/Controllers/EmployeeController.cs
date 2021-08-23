using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SEDCWebApplication.Models;
using SEDCWebApplication.Models.IRepository;
using SEDCWebApplication.ViewModels;

namespace SEDCWebApplication.Controllers
{
    public class EmployeeController : Controller
    {
        private IEmployeeRepository _employeeRepository;

        public EmployeeController (IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public IActionResult Index()
        {
            List<Employee> employees = _employeeRepository.GetAllEmplyees().ToList();


            List<EmployeeDTO> employeeVM = new List<EmployeeDTO>();
            foreach (Employee employee in employees) {
                EmployeeDTO employeedto = new EmployeeDTO();
                employeedto.Id = employee.Id;
                employeedto.Name = employee.Name;
                employeedto.Company= employee.Company;
                employeedto.Email= employee.Email;
                employeedto.ImagePath = employee.ImagePath;
                employeedto.Role = employee.Role;
                employeeVM.Add(employeedto);

            }
            return View(employeeVM);
        }

        [Route("Employee/Details/{id}")]
        public IActionResult Details(int id)
        {
            Employee employee = _employeeRepository.GetById(id);
            EmployeeDTO employeedto = new EmployeeDTO();
            employeedto.Id = employee.Id;
            employeedto.Name = employee.Name;
            employeedto.Company = employee.Company;
            employeedto.Email = employee.Email;
            employeedto.Role = employee.Role;
            return View(employeedto);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Employee employee)
        {
            if (ModelState.IsValid) {
                Employee newEmployee = _employeeRepository.Add(employee);
                return RedirectToAction("Details", new { id = newEmployee.Id });
            }
            else {
                return View();
            }

        }
    }
}
