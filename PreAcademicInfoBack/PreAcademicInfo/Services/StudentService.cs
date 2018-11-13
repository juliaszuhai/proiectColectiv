using PreAcademicInfo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PreAcademicInfo.Services
{
    public class StudentService
    {
        StudentContext context;

        public StudentService(StudentContext context)
        {
            this.context = context;
        }

        public List<Grade> GetGrades(string username,string discipline)
        {
            Student currentStudent = context.Student.Where(s => s.Username == username).Select(s => s).FirstOrDefault();
            return currentStudent.Grades.Where(g => g.Discipline.Nume == discipline)
                                        .Select(g => g.Grades).First().ToList();
        }
    }
}
