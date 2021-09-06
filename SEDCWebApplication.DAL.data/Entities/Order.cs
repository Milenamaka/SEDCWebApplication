using System;
using System.Collections.Generic;
using System.Text;

namespace SEDCWebApplication.DAL.Data.Entities
{
    public class Order : BaseEntity
    {
        public Order(int? id)
            : base(id)
        {
        }
        public string Number { get; set; }

        public DateTime Date { get; set; }

        public decimal TotalAmount { get; set; }

        public int Status { get; set; }

    }
}
