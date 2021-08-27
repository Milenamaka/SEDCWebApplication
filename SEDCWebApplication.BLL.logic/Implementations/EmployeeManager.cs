using AutoMapper;
using SEDCWebApplication.BLL.logic.Interfaces;
using SEDCWebApplication.BLL.logic.Models;
using SEDCWebApplication.BLL.logic.Interfaces;
using SEDCWebApplication.BLL.logic.Models;
using SEDCWebApplication.DAL.data.Entities;
using SEDCWebApplication.DAL.data.Interfaces;
using SEDCWebApplication.DAL.data.Entities;
using SEDCWebApplication.DAL.data.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SEDCWebApplication.BLL.logic.Implementations
{
    public class EmployeeManager : IEmployeeManager
    {
        private readonly IEmployeeDAL _employeeDAL;
        private readonly IMapper _mapper;
        public EmployeeManager(IEmployeeDAL employeeDAL, IMapper mapper)
        {
            _employeeDAL = employeeDAL;
            _mapper = mapper;
        }
        public EmployeeDTO Add(EmployeeDTO employee)
        {
            //Employee employeeEntity = new Employee(null)
            //{
            //    Name = employee.Name,
            //    UserName = employee.Email
            //};
            Employee employeeEntity = _mapper.Map<Employee>(employee);
            _employeeDAL.Save(employeeEntity);
            return employee;
        }

        public IEnumerable<EmployeeDTO> GetAllEmployees()
        {
            return _mapper.Map<List<EmployeeDTO>>(_employeeDAL.GetAll(0, 5));
        }

        public EmployeeDTO GetEmployeeById(int id)
        {
            return _mapper.Map<EmployeeDTO>(_employeeDAL.GetById(id));
        }
    }
}
