using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SEDCWebApplication.BLL.logic.Models;

namespace SEDCWebApplication.Models.IRepository
{
    public interface IEmployeeRepository
    {
        IEnumerable<EmployeeDTO> GetAllEmployees();

        EmployeeDTO GetEmployeeById(int id);
        EmployeeDTO Add(EmployeeDTO employee);
    }
}
