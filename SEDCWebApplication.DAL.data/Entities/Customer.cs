using System;
using System.Collections.Generic;
using System.Text;

namespace SEDCWebApplication.DAL.data.Entities
{
    public class Customer : User
    {
        public Customer(int? id)
        : base(id)
        {
        }
        public string Name { get; set; }
     
        public string Address { get; set; }
        public int ContactId { get; set; }

        public string Email { get; set; }
    }
}
