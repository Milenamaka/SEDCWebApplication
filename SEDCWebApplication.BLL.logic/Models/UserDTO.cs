using System;
using System.Collections.Generic;
using System.Text;

namespace SEDCWebApplication.BLL.logic.Models
{
    public class UserDTO
    {

        public int Id { get; set; }

        public string UserName { get; set; }

        public string Token { get; set; }

        public string Role { get; set; }
    }
}
