using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SEDCWeb1API.Service.Interfaces;
using SEDCWebApplication.BLL.logic.Interfaces;
using SEDCWebApplication.BLL.logic.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SEDCWeb1API.Service.Implementations
{
    public class UserService : IUserService
    {
        private readonly IUserManager _userManager;

        private readonly IConfiguration _configuration;
        public UserService(IUserManager userManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _configuration = configuration;
        }
        public UserDTO Authenticate(string username, string password)
        {
            UserDTO user = _userManager.GetUserByUserNameAndPassword(username, password);

            if (user == null)
                return null;


            // JWT token generate

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration.GetSection("AppSettings")["Secret"]);

            var tokenDescriptor = new SecurityTokenDescriptor {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString()),
                    new Claim(ClaimTypes.Role, user.Role)
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)

            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            user.Token = tokenHandler.WriteToken(token);

            return user;
        }

        public UserDTO GetById(int id)
        {
            try {
                return _userManager.GetById(id);
            }
            catch (Exception ex) {
                throw ex;
            }

        }
    }
}

