using SEDCWebApplication.BLL.logic.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SEDCWeb1API.Service.Interfaces
{
    public interface IOrderService
    {
        OrderDTO Add(OrderDTOnew order, int userId);

        OrderDTO GetById(int id);

        IEnumerable<OrderDTO> GetAll();

        OrderDTO Delete(OrderDTO order);

        IEnumerable<OrderDTO> GetOrdersByCustomerId(int id);
    }
}
