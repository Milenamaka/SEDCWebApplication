using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SEDCWebApplication.BLL.logic.Models;
using SEDCWebApplication.Models;
using SEDCWebApplication.Models.IRepository;
using SEDCWebApplication.ViewModels;

namespace SEDCWebApplication.Controllers
{
    [Authorize]
    [Route("Employee")]
    public class EmployeeController : Controller
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

        [AllowAnonymous]
        [Route("List")]
        public IActionResult List()
        {

            List<EmployeeDTO> employees = _employeeRepository.GetAllEmployees().ToList();

            List<EmployeeUpdateViewModel> employeesVM = new List<EmployeeUpdateViewModel>();
            foreach (EmployeeDTO employeeDTO in employees) {
                EmployeeUpdateViewModel employeeVM = new EmployeeUpdateViewModel();
                employeeVM.Id = (Int32)employeeDTO.Id;
                employeeVM.Name = employeeDTO.Name;
                employeeVM.Email = employeeDTO.Email;
                employeeVM.ImagePath = employeeDTO.ImagePath;
                employeeVM.ControllerName = "employee";
                employeesVM.Add(employeeVM);

            }
            return View(employeesVM);
        }

        [Route("Details/{id}")]
        public IActionResult Details(int id)
        {

                

                EmployeeDTO employee = _employeeRepository.GetEmployeeById(id);


                EmployeeDetailsViewModel employeeVM = new EmployeeDetailsViewModel();
                employeeVM.Name = employee.Name;
                employeeVM.Role = employee.Role;
                employeeVM.ImagePath = employee.ImagePath;
                employeeVM.PageTitle = "Employee's details";

                return View(employeeVM);


        }

        [HttpGet]
        public IActionResult Create()
        {
            //EmployeeDetailsViewModel employeeVM = new EmployeeDetailsViewModel();
            /*employeeVM.Roles = new List<SelectListItem>
            {
                new SelectListItem {Text = "Shyju", Value = "1"},
                new SelectListItem {Text = "Sean", Value = "2"}
            };*/
            return View();
        }

        [HttpPost]
        public IActionResult Create(EmployeeCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = "avatar.png";
                if (model.Photo != null)
                {
                    string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "img");

                    uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Photo.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    model.Photo.CopyTo(new FileStream(filePath, FileMode.Create));
                }


                EmployeeDTO employee = new EmployeeDTO
                {
                    Id = null,
                    Name = model.Name,
                    Email = model.Email,
                    Role = model.Role,
                    ImagePath = "~/img/" + uniqueFileName
                };
                EmployeeDTO newEmployee = _employeeRepository.Add(employee);
                return RedirectToAction("Details", new { id = newEmployee.Id });
            } else
            {
                return View();
            }
            
        }
    }
}
