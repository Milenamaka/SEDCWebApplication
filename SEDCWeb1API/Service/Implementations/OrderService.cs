using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SEDCWeb1API.Service.Interfaces;
using SEDCWebApplication.BLL.logic.Interfaces;
using SEDCWebApplication.BLL.logic.Models;
using SEDCWebApplication.DAL.DatabaseFactory;
using SEDCWebApplication.DAL.DatabaseFactory.Entities;
using SEDCWebApplication.DAL.DatabaseFactory.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace SEDCWeb1API.Service.Implementations
{
    public class OrderService : IOrderService
    {
        private readonly IOrderManager _orderManager;
        public OrderService(IOrderManager orderManager)
        {
            _orderManager = orderManager;
        }
        public IEnumerable<OrderDTO> GetAll()
        {
            return _orderManager.GetAllOrders();
        }

        public OrderDTO GetById(int id)
        {
            try {
                return _orderManager.GetById(id);
            }
            catch (Exception ex) {
                throw ex;
            }

        }

        public OrderDTO Add(OrderDTOnew order)
        {
            return _orderManager.Add(order);
        }
        public OrderDTO Delete(OrderDTO order)
        {
            return _orderManager.Delete(order);
        }
    }
}

