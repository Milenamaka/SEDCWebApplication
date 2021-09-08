using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SEDCWebApplication.BLL.logic.Models;

namespace SEDCWebApplication.ViewModels
{
    public class EmployeeUpdateViewModel
    {
        public int Id { get; set; }
     
        public string Name { get; set; }

      
        public string Email { get; set; }

        public RoleEnum Role { get; set; }

        public string ImagePath { get; set; }

        public string ControllerName { get; set; }
    }
}
