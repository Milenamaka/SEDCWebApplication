using System;
using System.Collections.Generic;
using System.Text;

namespace SEDCWebApplication.DAL.DatabaseFactory.Entities
{
    public class Order 
    {

        public int OrderId { get; set; }

        public string Number { get; set; }
        public DateTime Date { get; set; }
        public decimal TotalAmount { get; set; }
        public int Status { get; set; }

        public int customerId { get; set; }
        public List<OrderItem> orderItems { get; set; }
        public Employee Employee { get; set; }
        public Customer customer { get; set; }

    }
}
