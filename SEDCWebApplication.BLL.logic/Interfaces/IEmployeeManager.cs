using SEDCWebApplication.BLL.logic.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SEDCWebApplication.BLL.logic.Interfaces
{
    public interface IEmployeeManager
    {
        IEnumerable<EmployeeDTO> GetAllEmployees();
        EmployeeDTO GetEmployeeById(int id);
        EmployeeDTO Add(EmployeeDTO employee);
        EmployeeDTO Delete(EmployeeDTO employee);
    }
}
