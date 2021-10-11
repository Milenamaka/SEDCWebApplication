using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using SEDCWebApplication.BLL.logic.Interfaces;
using SEDCWebApplication.BLL.logic.Models;
using SEDCWebApplication.DAL.DatabaseFactory.Entities;
using SEDCWebApplication.DAL.DatabaseFactory.Interfaces;
//using SEDCWebApplication.DAL.data.Entities;
//using SEDCWebApplication.DAL.data.Interfaces;
//using SEDCWebApplicationEntityFactory.Entities;
//using SEDCWebApplicationEntityFactory.Interfaces;

namespace SEDCWebApplication.BLL.logic.Implementations
{
    public class OrderManager : IOrderManager
    {

        private readonly IOrderDAL _orderDAL;
        private readonly IProductDAL _productDAL;
        private readonly IMapper _mapper;
        public OrderManager(IOrderDAL ordertDAL, IProductDAL productDAL, IOrderItemDAL orderItem, IMapper mapper)
        {
            _orderDAL = ordertDAL;
            _productDAL = productDAL;
            _mapper = mapper;
        }
        public OrderDTO Add(OrderDTOnew orderDTO)
        {
            Order order = new Order();
            order.TotalAmount = 0;
            //order.Number = CreateOrderNumber();
            order.Status = 1;
            order.orderItems = new List<OrderItem>();
            foreach (OrderItemDTOnew orderItemDTO in orderDTO.OrderItems) {
             Product product = _productDAL.GetById((int)orderItemDTO.orderItem);
                order.TotalAmount += product.UnitPrice * orderItemDTO.quantity;

                OrderItem orderItem = new OrderItem();
                orderItem.ProductId = product.Id;
                orderItem.Quantity = orderItemDTO.quantity;

                order.orderItems.Add(orderItem);
            }
          
            _orderDAL.Save(order);
     
            return null;
        }
        public OrderDTO Delete(OrderDTO order)
        {

            Order orderEntity = _mapper.Map<Order>(order);
            _orderDAL.Delete(orderEntity);
            order = _mapper.Map<OrderDTO>(orderEntity);
            return order;
        }

        public IEnumerable<OrderDTO> GetAllOrders()
        {
            return _mapper.Map<List<OrderDTO>>(_orderDAL.GetAll(0, 50));
        }

        public OrderDTO GetById(int id)
        {
            return _mapper.Map<OrderDTO>(_orderDAL.GetById(id));
        }

        private string CreateOrderNumber()
        {
            return "N";
        }
    }
}
