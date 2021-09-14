using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using SEDCWeb1API.IRepository;
using SEDCWebApplication.BLL.logic.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SEDCWeb1API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        private readonly IProductRepository _productRepository;
        private readonly IHostingEnvironment _hostingEnvironment;
        public ProductController(IProductRepository productRepository, IHostingEnvironment hostingEnvironment)
        {
            _productRepository = productRepository;
            _hostingEnvironment = hostingEnvironment;
        }
       
        [HttpGet]
        public IEnumerable<ProductDTO> Get()
        {
            return _productRepository.GetAllProducts();
        }

        // GET api/<ProductController>/5

    
        [HttpGet("{id}")]
        public ProductDTO GetById(int id)
        {
            return _productRepository.GetById(id);
        }

        // POST api/<ProductController>
        [HttpPost]
        public ProductDTO Post([FromBody] ProductDTO newProduct)
        {
            ProductDTO product = new ProductDTO {
                ProductName = newProduct.ProductName,
                Size = newProduct.Size,
                UnitPrice = newProduct.UnitPrice,
                Description = newProduct.Description,
                IsDiscounted = newProduct.IsDiscounted,
                ImagePath = newProduct.ImagePath
            };
            return _productRepository.Add(product);
        }

        // PUT api/<ProductController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            _productRepository.Delete(_productRepository.GetById(id));

            return "Proizvod je obrisan!";
        }
    }
}
