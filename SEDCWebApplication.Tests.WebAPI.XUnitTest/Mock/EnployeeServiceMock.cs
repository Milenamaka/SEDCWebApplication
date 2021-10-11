using SEDCWeb1API.Service.Interfaces;
using SEDCWebApplication.BLL.logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SEDCWebApplication.Tests.WebAPI.XUnitTest.Mock
{
    public class EmployeeServiceMock : IEmployeeService
    {

        private List<EmployeeDTO> _employeeList;
        public EmployeeServiceMock()
        {
            _employeeList = new List<EmployeeDTO>
            {
                new EmployeeDTO
                {
                    Id=1,
                    Name="Pera",
                    Role=RoleEnum.Manager,
                    ImagePath = "~/img/avatar.png",
                    Test = true
                },
                new EmployeeDTO
                {
                    Id=2,
                    Name="Mika",
                    Role=RoleEnum.Sales,
                    ImagePath = "~/img/avatar.png",
                    Test = false
                },
                new EmployeeDTO
                {
                    Id=3,
                    Name="Laza",
                    Role=RoleEnum.Operater,
                    ImagePath = "~/img/avatar.png"
                }
            };
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

        public IEnumerable<EmployeeDTO> GetAllEmployees()
        {
            return _employeeList;
        }

        public EmployeeDTO GetEmployeeById(int id)
        {
            return _employeeList.Where(x => x.Id == id).FirstOrDefault();
        }

        public IEnumerable<OrderDTO> GetOrdersByCustomerId(int id)
        {
            throw new NotImplementedException();
        }

        public EmployeeDTO UpdateEmployee(int id, EmployeeDTO employee)
        {
            throw new NotImplementedException();
        }
    }
}
