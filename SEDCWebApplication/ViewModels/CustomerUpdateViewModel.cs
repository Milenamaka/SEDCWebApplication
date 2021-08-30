using System;
using SEDCWebApplication.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SEDCWebApplication.ViewModels
{
    public class CustomerUpdateViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public string Address { get; set; }

        public int ContactId { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        public string ImagePath { get; set; }
    }
}
