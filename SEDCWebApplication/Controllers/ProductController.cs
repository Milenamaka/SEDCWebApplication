using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
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
        private readonly IHostingEnvironment _hostingEnvironment;
        public ProductController(IProductRepository productRepository, IHostingEnvironment hostingEnvironment)
        {
            _productRepository = productRepository;
            _hostingEnvironment = hostingEnvironment;
        }
        [Route("ListDTO")]
        public IActionResult ListDTO()
        {
            List<Product> products = _productRepository.GetAllProducts().ToList();
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
        public IActionResult Create(ProductCreateDTO model)
        {
            if (ModelState.IsValid) {
                string uniqueFileName = "logoPizza.png";

                if (model.Photo != null) {
                    string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "img");

                    uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Photo.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    model.Photo.CopyTo(new FileStream(filePath, FileMode.Create));
                }


                Product product = new Product {
                    ProductName = model.ProductName,
                    Size = model.Size,
                    UnitPrice = model.UnitPrice,
                    Description = model.Description,
                    IsDiscounted = model.IsDiscounted,
                    ImagePath = "/img/" + uniqueFileName
                }; 
                Product newProduct = _productRepository.Add(product);
                return RedirectToAction("Details", new { id = newProduct.Id });
            }
            else {
                return View();
            }

        }
        [Route("Update/{id}")]
        [HttpGet]
        public IActionResult Update(int id)
        {
            Product product = _productRepository.GetById(id);
            return View(product);
        }
        [Route("Update/{Product changedProduct}")]
        [HttpPost]
        public IActionResult Update(Product changedProduct)
        {
            if (ModelState.IsValid) {
                Product product = _productRepository.GetById(changedProduct.Id);

                product.ProductName = changedProduct.ProductName;
                product.UnitPrice = changedProduct.UnitPrice;
                product.IsDiscounted = changedProduct.IsDiscounted;
                product.Size = changedProduct.Size;
                return RedirectToAction("Details", new { id = changedProduct.Id });
            }
            else {
                return View();
            }

        }
    }

}
