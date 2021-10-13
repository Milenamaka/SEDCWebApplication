using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SEDCWeb1API.Helpers;
using SEDCWeb1API.Service.Interfaces;
using SEDCWebApplication.BLL.logic.Models;

namespace SEDCWeb1API.Controllers
{

    [EnableCors("mypolicy")]
    [Route("api/[controller]")]
    [ApiController]

    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;

        private readonly IWebHostEnvironment _hostingEnvironment;

        private readonly IUserService _userService;

       
        public OrderController(IOrderService orderService, IWebHostEnvironment hostingEnvironment, IUserService userService)
        {
            _orderService = orderService;
            _hostingEnvironment = hostingEnvironment;
            _userService = userService;
        }

        // GET: api/<OrderController>


        [HttpGet]
        public IEnumerable<OrderDTO> Get()
        {
            return _orderService.GetAll();
        }


        [HttpGet("{id}")]
        public OrderDTO Get(int id)
        {
            return _orderService.GetById(id);
        }


        [Authorize(Roles = AuthorizationRoles.Client)]
        [HttpPost]

        public OrderDTO Post([FromBody] OrderDTOnew order)
        {
            UserDTO user = (UserDTO)HttpContext.Items["User"];
            return _orderService.Add(order, user.Id);
        }


        // GET: api/<OrderController>
        [Route("my")]
        [Authorize(Roles = AuthorizationRoles.Client)]
        [HttpGet]
        public IEnumerable<OrderDTO> GetAllMyOrders()
        {
            UserDTO user = (UserDTO)HttpContext.Items["User"];
            return _orderService.GetOrdersByCustomerId(user.Id);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

     
        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            _orderService.Delete(_orderService.GetById(id));

            return "order je obrisan!";
        }
    }
}
