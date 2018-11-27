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
        private readonly StudentContext _student_context;
        private readonly TeachersContext _teacher_context;
        private readonly AdminsContext _admin_context;

        public LoginController(StudentContext student_context, TeachersContext teacher_context, AdminsContext admin_context)
        {
            _student_context = student_context;
            _teacher_context = teacher_context;
            _admin_context = admin_context;
        }

        [HttpPost]
        public IActionResult Post([FromBody] JUser user)
        {
            User student  = _student_context.Student.FirstOrDefault< Student>(e => e.Username == user.username);
            //User teacher = _teacher_context.Teacher.FirstOrDefault< Teacher>(e => e.Username == Username);
            //User admin = _admin_context.Admin.FirstOrDefault< Admin>(e => e.Username == Username);
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
            //if (teacher != null)
            //{
            //    if (student.Password != Password)
            //    {
            //        return NotFound("invalid password");
            //    }
            //    else
            //    {
            //        return Ok(new UserNoPassword(student));
            //    }
            //}
            //if (admin != null)
            //{
            //    if (student.Password != Password)
            //    {
            //        return NotFound("invalid password");
            //    }
            //    else
            //    {
            //        return Ok(new UserNoPassword(student));
            //    }
            //}
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
