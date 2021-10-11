using SEDCWebApplication.BLL.logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEDCWeb1API.Service.Interfaces
{
    public interface IEmployeeService
    {
        IEnumerable<EmployeeDTO> GetAllEmployees();
        EmployeeDTO GetEmployeeById(int id);
        EmployeeDTO Add(EmployeeDTO employee);

        EmployeeDTO Delete(EmployeeDTO employee);
    }
}
