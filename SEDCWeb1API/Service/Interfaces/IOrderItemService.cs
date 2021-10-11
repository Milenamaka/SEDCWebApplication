
using System;
using System.Collections.Generic;
using System.Text;
using SEDCWebApplication.BLL.logic.Models;

namespace SEDCWeb1API.Service.Interfaces
{
    public interface IOrderItemService
    {
        OrderItemDTO Add(OrderItemDTO item);

        OrderItemDTO GetById(int id);

        IEnumerable<OrderItemDTO> GetAll();

        OrderItemDTO Delete(OrderItemDTO orderItem);
    }
}
