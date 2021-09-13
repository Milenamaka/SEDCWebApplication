using System;
using System.Collections.Generic;

#nullable disable

namespace SEDCWebApplicationEntityFactory.Entities
{
    public partial class Employee
    {
        public Employee()
        {
            Orders = new HashSet<Order>();
        }

        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public int RoleId { get; set; }
        public string Pol { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string ImagePath { get; set; }

        public virtual User EmployeeNavigation { get; set; }
        public virtual Role Role { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
