using AutoMapper;
using SEDCWebApplication.BLL.logic.Interfaces;
using SEDCWebApplication.BLL.logic.Models;
using SEDCWebApplication.DAL.DatabaseFactory.Entities;
using SEDCWebApplication.DAL.DatabaseFactory.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SEDCWebApplication.BLL.logic.Implementations
{
    public class UserManager : IUserManager
    {
        private readonly IUserDAL _userDAL;
        private readonly IMapper _mapper;
        public UserManager(IUserDAL userDAL, IMapper mapper)
        {
            _userDAL = userDAL;
            _mapper = mapper;
        }
        public UserDTO GetUserByUserNameAndPassword(string username, string password)
        {
            try {
                User user = _userDAL.GetUserByUserNameAndPassword(username, password);

                UserDTO userDTO = _mapper.Map<UserDTO>(user);
                return userDTO;
            }
            catch (Exception ex) {
                throw ex;
            }
        }

        public UserDTO GetById(int id)
        {
            try {
                User user = _userDAL.GetUserById(id);

                UserDTO userDTO = _mapper.Map<UserDTO>(user);
                return userDTO;
            }
            catch (Exception ex) {
                throw ex;
            }
        }
    }
}
