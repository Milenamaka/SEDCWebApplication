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
            List<ProductDTO> productsDTO = _productRepository.GetAllProducts().ToList();
            List<ProductUpdateViewModel> productsVM = new List<ProductUpdateViewModel>();
            foreach (ProductDTO productDTO in productsDTO) {
                ProductUpdateViewModel productvm = new ProductUpdateViewModel();
                productvm.ImagePath = productDTO.ImagePath;
                productvm.ProductName = productDTO.ProductName;
                productvm.Id = (Int32)productDTO.Id;
                productvm.UnitPrice = productDTO.UnitPrice;
                productvm.IsDiscounted = productDTO.IsDiscounted;
                string discount = productvm.IsDiscounted ? "\nDiscounted Now!!!" : "Regular Price";
                productvm.Size = productDTO.Size;
                productvm.Description = productDTO.Description;
                productsVM.Add(productvm);

            }
            return View(productsVM);
        }

        [HttpGet]
        [Route("Details/{id}")]
        public IActionResult Details(int id)
        {
            ProductDTO productdto = _productRepository.GetById(id);
            ProductUpdateViewModel productvm = new ProductUpdateViewModel();
            productvm.ProductName = productdto.ProductName;
            productvm.Id = (Int32)productdto.Id;
            productvm.UnitPrice = productdto.UnitPrice;
            productvm.IsDiscounted = productdto.IsDiscounted;
            productvm.Size = productdto.Size;
            productvm.ImagePath = productdto.ImagePath;
            productvm.Description= productdto.Description;
            return View(productvm);

        }


        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(ProductCreateViewModel model)
        {
            if (ModelState.IsValid) {
                string uniqueFileName = "logoPizza.png";

                if (model.Photo != null) {
                    string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "img");

                    uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Photo.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    model.Photo.CopyTo(new FileStream(filePath, FileMode.Create));
                }


                ProductDTO product = new ProductDTO {
                    ProductName = model.ProductName,
                    Size = model.Size,
                    UnitPrice = model.UnitPrice,
                    Description = model.Description,
                    IsDiscounted = model.IsDiscounted,
                    ImagePath = "/img/" + uniqueFileName
                }; 
                ProductDTO newProduct = _productRepository.Add(product);
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
            ProductDTO product = _productRepository.GetById(id);
            return View(product);
        }
        [Route("Update/{Product changedProduct}")]
        [HttpPost]
        public IActionResult Update(ProductUpdateViewModel changedProduct)
        {
            if (ModelState.IsValid) {
                ProductDTO product = _productRepository.GetById(changedProduct.Id);

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
