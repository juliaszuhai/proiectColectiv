using PreAcademicInfo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PreAcademicInfo.Services
{
    public class AdminService
    {
        StudentContext studentContext;

        public AdminService(StudentContext contextStudent)
        {
            this.studentContext = contextStudent;
        }

        public List<Teacher> getTeachers()
        {

            return studentContext.Teacher.ToList();
        }


    }
}
