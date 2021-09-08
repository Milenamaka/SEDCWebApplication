using SEDCWebApplication.DAL.data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SEDCWebApplication.DAL.data.Interfaces
{
    public interface IEmployeeDAL
    {
        void Save(Employee item);

        Employee GetById(int id);

        List<Employee> GetAll(int skip, int take);
    }
}
