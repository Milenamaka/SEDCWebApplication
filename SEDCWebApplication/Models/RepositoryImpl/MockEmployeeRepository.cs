using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SEDCWebApplication.BLL.logic.Models;
using SEDCWebApplication.Models.IRepository;

namespace SEDCWebApplication.Models.RepositoryImpl
{
    public class MockEmployeeRepository : IEmployeeRepository
    {


        private List<EmployeeDTO> _employeeList;

        public MockEmployeeRepository()
        {
            _employeeList = new List<EmployeeDTO>
            {
                new EmployeeDTO
                {
                    Id=1,
                    Name="Pera",
               
                    Email="pera@gmail.com",
                   ImagePath ="/img/pera.jpg",
                    Role = RoleEnum.Manager
        },
                new EmployeeDTO
                {
                    Id=2,
                    Name="Mika",
                  
                    Email="mika@gmail.com",
                    ImagePath ="/img/mika.jpg",
                    Role = RoleEnum.Sales
                },
                new EmployeeDTO
                {
                    Id=3,
                    Name="Laza",
               
                    Email="laza@gmail.com",
                    ImagePath ="/img/laza.jpg",
                    Role = RoleEnum.Sales
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
    }
}
