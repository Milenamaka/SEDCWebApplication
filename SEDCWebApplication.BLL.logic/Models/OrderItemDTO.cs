using System;
using System.Collections.Generic;
using System.Text;

namespace SEDCWebApplication.BLL.logic.Models
{ 
    public class OrderItemDTO
    {
        public int OrderItem { get; set; }
        public ProductDTO product { get; set; }
        public int Quantity { get; set; }

        public OrderDTO order { get; set; }
    }
}
