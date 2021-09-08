using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SEDCWebApplication.ViewModels
{
    public class ProductUpdateViewModel
    {
        public string ImagePath { get; set; }
        [Required]
        public string Name { get; set; }

        public int Id { get; set; }

        public int UnitPrice { get; set; }

        public String Size { get; set; }

        public Boolean IsDiscounted { get; set; }

        public String Description { get; set; }

    }
}
