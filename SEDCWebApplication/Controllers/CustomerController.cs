using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using SEDCWebApplication.BLL.logic.Models;
using SEDCWebApplication.Models;
using SEDCWebApplication.Models.IRepository;
using SEDCWebApplication.ViewModels;

namespace SEDCWebApplication.Controllers
{
    [Route("Customer")]
    public class CustomerController : Controller
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IWebHostEnvironment _hostingEnvironment;


        public CustomerController(ICustomerRepository customerRepository, IWebHostEnvironment hostingEnvironment)
        {


            _customerRepository = customerRepository;
            _hostingEnvironment = hostingEnvironment;
        }
        [Route("List")]
        public IActionResult List()
        {
            List<CustomerDTO> customers = _customerRepository.GetAllCustomers().ToList();

            List<CustomerUpdateViewModel> customersVM = new List<CustomerUpdateViewModel>();
            foreach (CustomerDTO customer in customers) {
                CustomerUpdateViewModel customerdto = new CustomerUpdateViewModel();
                customerdto.Id = (Int32)customer.Id;
                customerdto.Name = customer.Name;
                customerdto.Address = customer.Address;
                customerdto.Email = customer.Email;
                customerdto.ImagePath = customer.ImagePath;
               // customerdto.ContactId = customer.ContactId;
                customersVM.Add(customerdto);
                
            }
         return View(customersVM); 
        }

        [Route("Details/{id}")]
        public IActionResult Details(int id)
        {
            CustomerDTO customer = _customerRepository.GetById(id);
            CustomerUpdateViewModel customerdto = new CustomerUpdateViewModel();
            customerdto.Id = (Int32)customer.Id;
            customerdto.Name = customer.Name;
            customerdto.Address = customer.Address;
            customerdto.Email = customer.Email;
            //customerdto.ContactId = customer.ContactId;
            customerdto.ImagePath = customer.ImagePath;
            return View(customerdto);

        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CustomerCreateViewModel model)
        {

            if (ModelState.IsValid) {
                string uniqueFileName = "avatar.png";
                if (model.Photo != null) {
                    string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "img");

                    uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Photo.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    model.Photo.CopyTo(new FileStream(filePath, FileMode.Create));
                }
                CustomerDTO customer = new CustomerDTO {
                    Id = null,
                    Name = model.Name,
                    Email = model.Email,
                   // ContactId = model.ContactId,
                    Address = model.Address,
                    ImagePath = "/img/" + uniqueFileName
                };
                CustomerDTO newCustomer = _customerRepository.Add(customer);
                return RedirectToAction("Details", new { id = newCustomer.Id });
            }
            else {
                return View();
            }

        }

    }
}
