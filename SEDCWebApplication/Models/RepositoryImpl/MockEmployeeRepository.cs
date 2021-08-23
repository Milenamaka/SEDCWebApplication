using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SEDCWebApplication.Models.IRepository;

namespace SEDCWebApplication.Models.RepositoryImpl
{
    public class MockEmployeeRepository : IEmployeeRepository
    {


        private List<Employee> _employeeList;

        public MockEmployeeRepository()
        {
            _employeeList = new List<Employee>
            {
                new Employee
                {
                    Id=1,
                    Name="Pera",
                    Company="Seavus",
                    Email="pera@gmail.com",
                   ImagePath ="/img/pera.jpg",
                    Role = RoleEnum.Manager
        },
                new Employee
                {
                    Id=2,
                    Name="Mika",
                    Company="Seavus",
                    Email="mika@gmail.com",
                    ImagePath ="/img/mika.jpg",
                    Role = RoleEnum.Sales
                },
                new Employee
                {
                    Id=3,
                    Name="Laza",
                    Company="Seavus",
                    Email="laza@gmail.com",
                    ImagePath ="/img/laza.jpg",
                    Role = RoleEnum.Operater
        }
            };
        }

        public List<Employee> GetAllEmplyees()
        {
            return _employeeList;
        }

        public Employee GetById(int id)
        {
          return _employeeList.Where(x => x.Id == id).FirstOrDefault();
        }
        public Employee Add(Employee employee)
        {
            employee.Id = _employeeList.Max(e => e.Id) + 1;
            _employeeList.Add(employee);
            return _employeeList.Where(x => x.Id == employee.Id).FirstOrDefault();
        }
    }
}
