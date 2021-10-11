using SEDCWebApplication.BLL.logic.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SEDCWebApplication.BLL.logic.Interfaces
{
    public interface IUserManager
    {
        UserDTO GetUserByUserNameAndPassword(string username, string password);
        UserDTO GetById(int id);
    }
}
