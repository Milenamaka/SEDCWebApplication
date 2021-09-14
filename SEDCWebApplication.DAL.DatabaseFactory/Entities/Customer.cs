using System;
using System.Collections.Generic;
using System.Text;

namespace SEDCWebApplication.DAL.DatabaseFactory.Entities
{
    public class Customer : User
    {
        public string Name { get; set; }

        public string Address { get; set; }
        // public int ContactId { get; set; }
        public string ImagePath { get; set; }
        public string Email { get; set; }
    }
}
