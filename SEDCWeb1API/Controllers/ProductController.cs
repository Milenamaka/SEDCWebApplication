using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using SEDCWeb1API.Helpers;
using SEDCWeb1API.Service.Interfaces;
using SEDCWebApplication.BLL.logic.Models;
using Serilog;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SEDCWeb1API.Controllers
{

    [EnableCors("mypolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        private readonly IProductService _productService;
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly ILogger _logger;
        public ProductController(IProductService productService, ILogger logger, IHostingEnvironment hostingEnvironment)
        {
            _productService = productService;
            _hostingEnvironment = hostingEnvironment;
            _logger = logger;
        }

        [Authorize(Roles = AuthorizationRoles.Admin)]
        [HttpGet]
        public ActionResult<IEnumerable<ProductDTO>> Get()
        {


            List<ProductDTO> products = _productService.GetAllProducts().ToList();

            return Ok(products);
        }

        // GET api/<ProductController>/5

        [Authorize(Roles = AuthorizationRoles.Admin)]
        [HttpGet("{id}")]
        public ActionResult<ProductDTO> GetById(int id)
        {
            return Ok(_productService.GetById(id));
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
            return _productService.Add(product);
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
            _productService.Delete(_productService.GetById(id));

            return "Proizvod je obrisan!";
        }
    }
}
