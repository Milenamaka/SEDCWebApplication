using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SEDCWeb1API.Service.Interfaces;
using SEDCWebApplication.BLL.logic.Models;
using SEDCWebApplication.DAL.DatabaseFactory.Implementations;

namespace SEDCWeb1API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("mypolicy")]

    public class OrderItemController : Controller
    {

        private readonly IOrderItemService _orderItemService;
        private readonly IWebHostEnvironment _hostingEnvironment;

        //private List<Employee> employees;

        public OrderItemController(IOrderItemService orderItemService, IWebHostEnvironment hostingEnvironment)
        {
            _orderItemService = orderItemService;
            _hostingEnvironment = hostingEnvironment;
 
        }

        [HttpGet]
        public IEnumerable<OrderItemDTO> Get()
        {
            return _orderItemService.GetAll();
        }


        [HttpGet("{id}")]
        public OrderItemDTO Get(int id)
        {
            return _orderItemService.GetById(id);
        }

        [HttpPost]
        public OrderItemDTO Post([FromBody] OrderItemDTO orderItem)
        {
            return _orderItemService.Add(orderItem);
        }

   
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            _orderItemService.Delete(_orderItemService.GetById(id));

            return "Proizvod je obrisan!";
        }
    }
}
