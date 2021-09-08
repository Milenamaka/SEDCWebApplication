using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using SEDCWebAPI.IRepository;
using SEDCWebApplication.BLL.logic.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SEDCWebAPI.Controllers
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
        [HttpGet]
    

        // POST api/<ProductController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ProductController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
