using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PreAcademicInfo.Models;
using BCrypt.Net;
namespace PreAcademicInfo.Controllers
{
    [ProducesResponseType(201)]
    [ProducesResponseType(400)]
    [Produces("application/json")]
    [Consumes("application/json")]
    [Route("api/Login")]
    public class LoginController : Controller
    {
        private readonly StudentContext _context;

        public LoginController(StudentContext student_context)
        {
            _context = student_context;
        }

        [HttpPost]
        public IActionResult Post([FromBody] JUser user)
        {
            User student  = _context.Student.FirstOrDefault< Student>(e => e.Username == user.username);
            User teacher = _context.Teacher.FirstOrDefault< Teacher>(e => e.Username == user.username);
            User admin = _context.Admin.FirstOrDefault< Admin>(e => e.Username == user.username);
            if (student != null)
            {
                
                if (!BCrypt.Net.BCrypt.Verify(student.Salt + user.password, student.Password))
                {   
                    return NotFound("invalid password");
                }
                else
                {    
                    return Ok(new UserNoPassword(student));
                }
            }
            if (teacher != null)
            {
                if (!BCrypt.Net.BCrypt.Verify(teacher.Salt + user.password, teacher.Password))
                {
                    return NotFound("invalid password");
                }
                else
                {
                    return Ok(new UserNoPassword(teacher));
                }
            }
            if (admin != null)
            {
                if (!BCrypt.Net.BCrypt.Verify(admin.Salt + user.password, admin.Password))
                {
                    return NotFound("invalid password");
                }
                else
                {
                    return Ok(new UserNoPassword(admin));
                }
            }
            else
            {
                return NotFound("inexistend user");
            }
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
        public class JUser
        {
            public string username { get; set; }
            public string password { get; set; }
        }
    }
}
