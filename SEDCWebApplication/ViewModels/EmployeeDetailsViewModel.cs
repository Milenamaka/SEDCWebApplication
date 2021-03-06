using SEDCWebApplication.BLL.logic.Models;
using SEDCWebApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEDCWebApplication.ViewModels
{
    public class EmployeeDetailsViewModel
    {
        public string ImagePath { get; set; }

        public string Name { get; set; }
        public string PageTitle { get; set; }

        public RoleEnum Role { get; set; }
        public int Id { get; set; }
      
    }
}
