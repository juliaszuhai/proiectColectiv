using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AcademicInfoServerEF22EF22.Models;
using BCrypt.Net;
using Microsoft.EntityFrameworkCore;
namespace AcademicInfoServerEF22.Controllers
{
    [ProducesResponseType(201)]
    [ProducesResponseType(400)]
    [Produces("application/json")]
    [Consumes("application/json")]
    [Route("api/ChangePass")]
    public class ChangePasswordController : Controller
    {
        private readonly AcademicInfoContext _context;

        public ChangePasswordController(AcademicInfoContext student_context)
        {
            _context = student_context;
        }

        [HttpPut]
        public async Task<IActionResult> Post([FromBody] JUser user)
        {
            User student = _context.Student.FirstOrDefault<Student>(e => e.Username == user.username);
            User teacher = _context.Teacher.FirstOrDefault<Teacher>(e => e.Username == user.username);
            User admin = _context.Admin.FirstOrDefault<Admin>(e => e.Username == user.username);
            if (student != null)
            {

                if (!BCrypt.Net.BCrypt.Verify(student.Salt + user.oldPassword, student.Password))
                {
                    return NotFound("invalid old password");
                }
                else
                {
                    student.Password = BCrypt.Net.BCrypt.HashPassword(student.Salt + user.newPassword);
                    _context.Entry(student).State = EntityState.Modified;
                    try
                    {
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
             
                            throw;
                        
                    }
                    return Ok(new UserNoPassword(student));
                }
            }
            if (teacher != null)
            {
                if (!BCrypt.Net.BCrypt.Verify(teacher.Salt + user.oldPassword, teacher.Password))
                {
                    return NotFound("invalid old password");
                }
                else
                {
                    teacher.Password = BCrypt.Net.BCrypt.HashPassword(teacher.Salt + user.newPassword);
                    _context.Entry(teacher).State = EntityState.Modified;
                    try
                    {
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {

                        throw;

                    }
                    return Ok(new UserNoPassword(teacher));
                }
            }
            if (admin != null)
            {
                if (!BCrypt.Net.BCrypt.Verify(admin.Salt + user.oldPassword, admin.Password))
                {
                    return NotFound("invalid old password");

                }
                else
                {
                    admin.Password = BCrypt.Net.BCrypt.HashPassword(admin.Salt + user.newPassword);
                    _context.Entry(admin).State = EntityState.Modified;
                    try
                    {
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        throw;
                    }
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
            public string oldPassword { get; set; }
            public string newPassword { get; set; }
            public string confirmNewPassword { get; set; }

        }
    }
}
