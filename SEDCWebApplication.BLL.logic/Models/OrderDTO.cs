using System;
using System.Collections.Generic;
using System.Text;
using SEDCWebApplication.DAL.DatabaseFactory.Entities;

namespace SEDCWebApplication.BLL.logic.Models
{
    public class OrderDTO 
    {

        public int OrderId { get; set; }

        public List<OrderItemDTO> orderItems { get; set; }
        public string Number { get; set; }
        public DateTime Date { get; set; }
        public decimal TotalAmount { get; set; }
        public int Status { get; set; }
        public EmployeeDTO Employee { get; set; }
        public CustomerDTO customer { get; set; }

    }
}
