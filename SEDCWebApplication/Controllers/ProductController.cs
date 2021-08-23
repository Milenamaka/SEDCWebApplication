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
    [Route("Product")]
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        [Route("ListDTO")]
        public IActionResult ListDTO()
        {
            List<Product> products = _productRepository.GetAllProducts().ToList();

            /*ViewBag.Customers = customers;
            ViewData["Customers"] = customers;
            ViewBag.Title = customers;
            ViewData["Title"] = "Customers";*/

            List<ProductDTO> productVM = new List<ProductDTO>();
            foreach (Product product in products) {
                ProductDTO productdto = new ProductDTO();
                productdto.ImagePath = product.ImagePath;
                productdto.ProductName = product.ProductName;
                productdto.Id = product.Id;
                productdto.UnitPrice = product.UnitPrice;
                productdto.IsDiscounted = product.IsDiscounted;
                string discount = productdto.IsDiscounted ? "\nDiscounted Now!!!" : " ";
                productdto.Size = product.Size;
                productdto.Description = product.Description;
                productVM.Add(productdto);

            }
            return View(productVM);
        }

        [Route("Details/{id}")]
        public IActionResult Details(int id)
        {
            Product product = _productRepository.GetById(id);
            ProductDTO productdto = new ProductDTO();
            productdto.ProductName = product.ProductName;
            productdto.Id = product.Id;
            productdto.UnitPrice = product.UnitPrice;
            productdto.IsDiscounted = product.IsDiscounted;
            productdto.Size = product.Size;
            return View(productdto);

        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Product product)
        {
            if (ModelState.IsValid) {
                Product newProduct = _productRepository.Add(product);
                return RedirectToAction("Details", new { id = newProduct.Id });
            }
            else {
                return View();
            }

        }

      /*  [HttpGet]
        public IActionResult Update()
        {
            return View();
        }

        [HttpPut]
        public IActionResult Update(int id)
        {
            if (ModelState.IsValid) {
                Product product = _productRepository.GetById(id);
                return RedirectToAction("Details", new { id = product.Id });
            }
            else {
                return View();
            }

        }*/
    }

}
