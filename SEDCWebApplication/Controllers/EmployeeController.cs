using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using SEDCWebApplication.BLL.logic.Models;
using SEDCWebApplication.DAL.data.Entities;
using SEDCWebApplication.Models;
using SEDCWebApplication.Models.IRepository;
using SEDCWebApplication.ViewModels;

namespace SEDCWebApplication.Controllers
{
    public class EmployeeController : Controller
    {
        private IEmployeeRepository _employeeRepository;
        private readonly IWebHostEnvironment _hostingEnvironment;

      
        public EmployeeController(IEmployeeRepository employeeRepository, IWebHostEnvironment hostingEnvironment)
        {


            _employeeRepository = employeeRepository;
            _hostingEnvironment = hostingEnvironment;
        }

        [Route("List")]
        public IActionResult List()
        {

            List<EmployeeDTO> employees = _employeeRepository.GetAllEmployees().ToList();
            List<EmployeeDTO> employeeVM = new List<EmployeeDTO>();
            ViewBag.Title = "Employees";

            return View(employees);
        }

        [Route("Employee/Details/{id}")]
        public IActionResult Details(int id)
        {
            EmployeeDTO employee = _employeeRepository.GetEmployeeById(id);

            //EmployeeDetailsViewModel employeeVM = new EmployeeDetailsViewModel
            //{
            //    Employee = employee,
            //    PageTitle = "Employee's details"
            //};

            EmployeeDetailsViewModel employeeVM = new EmployeeDetailsViewModel();
            employeeVM.EmployeeName = employee.Name;
            //employeeVM.EmployeeCompany = employee.Company;
            employeeVM.PageTitle = "Employee's details";

            return View(employeeVM);
    
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(EmployeeCreateViewModel model)
        {
            if (ModelState.IsValid) {
                string uniqueFileName = "avatar.png";
                if (model.Photo != null) {
                    string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "img");

                    uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Photo.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    model.Photo.CopyTo(new FileStream(filePath, FileMode.Create));
                }
                EmployeeDTO employee = new EmployeeDTO {
                    Name = model.Name,
                    Email = model.Email,
                    Role = model.Role,
                    ImagePath = "~/img/" + uniqueFileName
                };
                EmployeeDTO newEmployee = _employeeRepository.Add(employee);
                return RedirectToAction("Details", new { id = newEmployee.Id });
            }
            else {
                return View();
            }

        }
    }
}
