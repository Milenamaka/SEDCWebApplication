using System;
using System.Collections.Generic;
using System.Text;

namespace SEDCWebApplication.DAL.DatabaseFactory.Entities
{
    public class Product
    {
        public int Id { get; set; }

        public string ProductName { get; set; }

        public int UnitPrice { get; set; }

        public Boolean IsDiscounted { get; set; }

        public Boolean IsActive { get; set; }

        public Boolean IsDeleted { get; set; }

        public String Size { get; set; }

        public string ImagePath { get; set; }

        public String Description { get; set; }
    }
}
