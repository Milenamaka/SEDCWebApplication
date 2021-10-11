using SEDCWeb1API.Service.Interfaces;
using SEDCWebApplication.BLL.logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEDCWebAPI.Repositories.Implementations
{
    public class MockEmployeeService : IEmployeeService
    {
        private List<EmployeeDTO> _employeeList;
        public MockEmployeeService()
        {
            _employeeList = new List<EmployeeDTO>
            {
                new EmployeeDTO
                {
                    Id=1,
                    Name="Pera",
                    ImagePath = "~/img/avatar.png",
                    Test = true
                },
                new EmployeeDTO
                {
                    Id=2,
                    Name="Mika",
                    ImagePath = "~/img/avatar.png",
                    Test = false
                },
                new EmployeeDTO
                {
                    Id=3,
                    Name="Laza",
                    ImagePath = "~/img/avatar.png"
                }
            };
        }

        public IEnumerable<EmployeeDTO> GetAllEmployees()
        {
            return _employeeList;
        }

        public EmployeeDTO GetEmployeeById(int id)
        {
            return _employeeList.Where(x => x.Id == id).FirstOrDefault();
        }

        public EmployeeDTO Add(EmployeeDTO employee)
        {
            employee.Id = _employeeList.Max(e => e.Id) + 1;
            _employeeList.Add(employee);
            return _employeeList.Where(x => x.Id == employee.Id).FirstOrDefault();
        }

        public EmployeeDTO Delete(EmployeeDTO employee)
        {
            throw new NotImplementedException();
        }
    }
}
