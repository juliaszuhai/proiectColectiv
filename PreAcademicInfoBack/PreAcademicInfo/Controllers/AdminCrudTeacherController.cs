using Microsoft.AspNetCore.Mvc;
using PreAcademicInfo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace PreAcademicInfo.Controllers
{

    [ProducesResponseType(201)]
    [ProducesResponseType(400)]
    [Produces("application/json")]
    [Consumes("application/json")]
    [Route("api/AdminCrudTeacher")]
    public class AdminCrudTeacherController: Controller
    {
        private readonly TeachersContext  teacherContext;

        public AdminCrudTeacherController(TeachersContext contextTeacher)
        {
            this.teacherContext = contextTeacher;
        }

        // GET: api/AdminCrudTeacher
        [HttpGet]
        public IEnumerable<Teacher> getTeachers()
        {
            return teacherContext.Teacher;
        }
    }
}
