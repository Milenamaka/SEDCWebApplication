﻿using System;
using System.Collections.Generic;
using System.Text;
using SEDCWebApplication.BLL.logic.Models;

namespace SEDCWebApplication.BLL.logic.Interfaces
{
    public interface IOrderManager
    {
        IEnumerable<OrderDTO> GetAllOrders();
        OrderDTO GetById(int id);

        OrderDTO Add(OrderDTOnew order);

        OrderDTO Delete(OrderDTO order);
    }
}
