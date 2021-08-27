using System;
using System.Collections.Generic;
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
        [Route("ListDTO")]
        public IActionResult ListDTO()
        {
            List<CustomerDTO> customers = _customerRepository.GetAllCustomers().ToList();

            List<CustomerCreateViewModel> customersVM = new List<CustomerCreateViewModel>();
            foreach (CustomerDTO customer in customers) {
                CustomerCreateViewModel customerdto = new CustomerCreateViewModel();
                customerdto.Id = customer.Id;
                customerdto.Name = customer.Name;
                customerdto.Address = customer.Address;
                customerdto.Email = customer.Email;
                customerdto.ContactId = customer.ContactId;
                customersVM.Add(customerdto);
                
            }
         return View(customersVM); 
        }

        [Route("Details/{id}")]
        public IActionResult Details(int id)
        {
            CustomerDTO customer = _customerRepository.GetById(id);
            CustomerCreateViewModel customerdto = new CustomerCreateViewModel();
            customerdto.Id = customer.Id;
            customerdto.Name = customer.Name;
            customerdto.Address = customer.Address;
            customerdto.Email = customer.Email;
            customerdto.ContactId = customer.ContactId;
            return View(customerdto);

        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CustomerDTO customer)
        {
            if (ModelState.IsValid) {
                CustomerDTO newCustomer = _customerRepository.Add(customer);
                return RedirectToAction("Details", new { id = newCustomer.Id });
            }
            else {
                return View();
            }

        }

    }
}
