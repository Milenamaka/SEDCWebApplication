using AutoMapper;
using SEDCWebApplication.BLL.logic.Interfaces;
using SEDCWebApplication.BLL.logic.Models;
using SEDCWebApplication.DAL.data.Entities;
using SEDCWebApplication.DAL.data.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SEDCWebApplication.BLL.Logic.Implementations
{
    public class EmployeeManager : IEmployeeManager
    {
        private readonly IEmployeeDAL _employeeDAL;
        private readonly IOrderDAL _orderDAL;
        private readonly IMapper _mapper;
        public EmployeeManager(IEmployeeDAL employeeDAL, IOrderDAL orderDAL, IMapper mapper)
        {
            _employeeDAL = employeeDAL;
            _orderDAL = orderDAL;
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
            employee = _mapper.Map<EmployeeDTO>(employeeEntity);
            return employee;
        }

        public IEnumerable<EmployeeDTO> GetAllEmployees()
        {
            List<EmployeeDTO> employeeDTOs =  _mapper.Map<List<EmployeeDTO>>(_employeeDAL.GetAll(0, 50));
            //foreach(EmployeeDTO employeeDTO in employeeDTOs)
            //{
            //    employeeDTO.Orders = _orderDAL.GetByEmployeeId((int)employeeDTO.Id);
            //}
            return employeeDTOs;
        }

        public EmployeeDTO GetEmployeeById(int id)
        {
            try
            {
                Employee employee = _employeeDAL.GetById(id);
                if (employee == null)
                {
                    throw new Exception($"Employee with id {id} not found.");
                }
                EmployeeDTO employeeDTO =_mapper.Map<EmployeeDTO>(employee);
                employeeDTO.Orders = _orderDAL.GetByEmployeeId((int)employee.Id);
                return employeeDTO;
            }
            catch(Exception ex)
            {
                throw ex;
            }

        }
    }
}
