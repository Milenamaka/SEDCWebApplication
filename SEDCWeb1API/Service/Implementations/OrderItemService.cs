using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SEDCWeb1API.Service.Interfaces;
using SEDCWebApplication.BLL.logic.Interfaces;
using SEDCWebApplication.BLL.logic.Models;
using SEDCWebApplication.DAL.DatabaseFactory;
using SEDCWebApplication.DAL.DatabaseFactory.Entities;
using OrderItemDTO = SEDCWebApplication.BLL.logic.Models.OrderItemDTO;

namespace SEDCWeb1API.Service.Implementations
{
    public class OrderItemService : IOrderItemService
    {
        private readonly IOrderItemManager _orderItemManager;
        public OrderItemService(IOrderItemManager orderItemManager)
        {
            _orderItemManager = orderItemManager;
        }
        public IEnumerable<OrderItemDTO> GetAll()
        {
            return _orderItemManager.GetAllOrderItems();
        }

        public OrderItemDTO GetById(int id)
        {
            try {
                return _orderItemManager.GetById(id);
            }
            catch (Exception ex) {
                throw ex;
            }

        }

        public OrderItemDTO Add(OrderItemDTO orderItem)
        {
            return _orderItemManager.Add(orderItem);
        }
        public OrderItemDTO Delete(OrderItemDTO orderItem)
        {
            return _orderItemManager.Delete(orderItem);
        }

       
    }
}
