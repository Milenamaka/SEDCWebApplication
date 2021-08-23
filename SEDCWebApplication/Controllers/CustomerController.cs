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
    [Route("Customer")]
    public class CustomerController : Controller
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;       
        }
        [Route("ListDTO")]
        public IActionResult ListDTO()
        {
            List<Customer> customers = _customerRepository.GetAllCustomers().ToList();

            List<CustomerDTO> customersVM = new List<CustomerDTO>();
            foreach (Customer customer in customers) {
                CustomerDTO customerdto = new CustomerDTO();
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
            Customer customer = _customerRepository.GetById(id);
            CustomerDTO customerdto = new CustomerDTO();
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
        public IActionResult Create(Customer customer)
        {
            if (ModelState.IsValid) {
                Customer newCustomer = _customerRepository.Add(customer);
                return RedirectToAction("Details", new { id = newCustomer.Id });
            }
            else {
                return View();
            }

        }
    }
}
