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
        TeachersContext teacherContext;

        public AdminService(StudentContext contextStudent, TeachersContext contextTeacher )
        {
            this.studentContext = contextStudent;
            this.teacherContext = contextTeacher;
        }

        public List<Teacher> getTeachers()
        {

            return teacherContext.Teacher.ToList();
        }


    }
}
