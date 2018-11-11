using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PreAcademicInfo.Models;

namespace PreAcademicInfo.Controllers
{
    [ProducesResponseType(200, Type = typeof(UserNoPassword))]
    [ProducesResponseType(404, Type = typeof(string))]
    [Route("api/Login")]
    public class LoginController : Controller
    {
        private readonly UsersContext _context;
        
        [HttpGet]
        public IActionResult Get([FromBody] String Username, [FromBody] String Password)
        {
            User user = _context.Users.First<User>(e => e.Username == Username);
            if (user != null)
            {
                if (user.Password != Password)
                {
                    return NotFound("invalid password");
                }

                else
                {    
                    return Ok(new UserNoPassword(user));
                }
            }
            else
                return NotFound("inexistend user");
        }

        private class UserNoPassword
        {
            public UserType UserType { get; set; }
            public String Username { get; set; }

            public UserNoPassword(User user)
            {
                UserType = user.UserType;
                Username = user.Username;
            }
        }
    }
}
