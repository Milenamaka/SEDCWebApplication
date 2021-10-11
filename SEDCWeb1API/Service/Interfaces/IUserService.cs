using SEDCWebApplication.BLL.logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEDCWeb1API.Service.Interfaces
{
    public interface IUserService
    {
        UserDTO Authenticate(string username, string password);

        UserDTO GetById(int id);
    }
}
