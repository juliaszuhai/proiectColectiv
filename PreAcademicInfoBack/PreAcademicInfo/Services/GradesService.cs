using PreAcademicInfo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PreAcademicInfo.Services
{
    public class GradesService
    {
        StudentContext context;

        public GradesService(StudentContext context)
        {
            this.context = context;
        }

        public List<Grade> GetGradesPerYear(string an)
        {

            List<Student> students = context.Student
                .Where(student => student.An == an)
                .Select(student => student).ToList();

            List<Grade> grades = new List<Grade>();
            foreach(Student student in students)
            {
                List<Grade> gradesPerStudent = student.Grades
                    .SelectMany(discipline => discipline.Grades.ToList()).ToList();

                gradesPerStudent.ForEach(grade => grades.Add(grade));
            }
            return grades;

        }

    }
}
