using SEDCWeb1API.IRepository;
using SEDCWebApplication.BLL.logic.Interfaces;
using SEDCWebApplication.BLL.logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace SEDCWeb1API.RepositoryImpl
{
    public class DatabaseEmployeeRepository : IEmployeeRepository
    {
        private readonly IEmployeeManager _employeeManager;
        public DatabaseEmployeeRepository(IEmployeeManager employeeManager)
        {
            _employeeManager = employeeManager;
        }
        public IEnumerable<EmployeeDTO> GetAllEmployees()
        {
            return _employeeManager.GetAllEmployees();
        }

        public EmployeeDTO GetEmployeeById(int id)
        {
            try
            {
                return _employeeManager.GetEmployeeById(id);
            }
            catch(Exception ex)
            {
                throw ex;
            }
            
        }

        public EmployeeDTO Add(EmployeeDTO employee)
        {
            return _employeeManager.Add(employee);
        }
    }
}
