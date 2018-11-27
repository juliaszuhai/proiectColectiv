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

        public List<Grade> GetAllGrades(string username,string discipline)
        {
            Student currentStudent = context.Student.Where(s => s.Username == username).Select(s => s).FirstOrDefault();
            return currentStudent.Grades.Where(g => g.Discipline.Nume == discipline)
                                        .Select(g => g.Grades).First().ToList();
        }

        public List<Grade> GetGradesByType(string username, string discipline, GradeType gradeType)
        {
            Student currentStudent = context.Student.Where(s => s.Username == username).Select(s => s).FirstOrDefault();
            return currentStudent.Grades.Where(g => g.Discipline.Nume == discipline)
                                        .Select(g => g.Grades).First().ToList()
                                        .Where(g => g.Type == gradeType).ToList();
        }


        public List<Grade> FilterGradesByYear(List<Grade> grades, int an)
        {
            return grades.Where(g => g.Discipline.An == an).ToList();
        }

        public List<Grade> FilterGradesByYearAndSemester(List<Grade> grades, int an,int semestru)
        {
            return grades.Where(g => g.Discipline.An == an && g.Discipline.Semestru == semestru).ToList();
        }
    }
}
