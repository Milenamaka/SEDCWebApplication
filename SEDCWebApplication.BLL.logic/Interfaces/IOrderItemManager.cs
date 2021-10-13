using System;
using System.Collections.Generic;
using System.Text;
using SEDCWebApplication.BLL.logic.Models;

namespace SEDCWebApplication.BLL.logic.Interfaces
{
    public interface IOrderItemManager
    {
        IEnumerable<OrderItemDTO> GetAllOrderItems();

        OrderItemDTO GetById(int id);

        OrderItemDTO Add(OrderItemDTO orderItem);

        OrderItemDTO Delete(OrderItemDTO orderItem);

      
    }
}
