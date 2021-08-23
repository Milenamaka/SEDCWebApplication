using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEDCWebApplication.Models.IRepository
{
    public interface IEmployeeRepository
    {
        List<Employee> GetAllEmplyees();

        Employee GetById(int id);
        Employee Add(Employee employee);
    }
}
