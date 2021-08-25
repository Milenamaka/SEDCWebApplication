using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace SEDCWebApplication.ViewModels
{
    public class ProductCreateDTO
    {
        public IFormFile Photo { get; set; }
        [Required]
        public string ProductName { get; set; }

        public int Id { get; set; }

        public int UnitPrice { get; set; }

        public String Size { get; set; }

        public Boolean IsDiscounted { get; set; }

        public String Description { get; set; }
    }
}
