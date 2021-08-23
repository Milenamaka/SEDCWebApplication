using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using SEDCWebApplication.Models;

namespace SEDCWebApplication.ViewModels
{
    public class EmployeeDTO
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public string Company { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public string ImagePath { get; set; }

        public RoleEnum Role { get; set; }
    }
}
