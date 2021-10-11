using System;
using System.Collections.Generic;
using System.Text;

namespace SEDCWebApplication.DAL.DatabaseFactory.Entities
{
    public class OrderItem
    {
        public int OrderItemId { get; set; }

        public int ProductId { get; set; }

        public int Quantity { get; set; }

        public Product product { get; set; }
        
        public Order order { get; set; }
    }
}
