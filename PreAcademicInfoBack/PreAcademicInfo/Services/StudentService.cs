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

        public HashSet<Student> FilterStudentsByFacultyName(string facultyName)
        {
            List<ICollection<Department>> departments = context.Faculty.Where(f => f.Nume == facultyName)
                .Select(f => f.Departments).ToList();
            HashSet<Student> students = new HashSet<Student>();
            foreach(var d in departments)
            {
                foreach (var dp in d)
                {
                    students.Concat(FilterStudentsByDepartmentName(dp.Name).ToList());
                }
            }
            return students;
            /*return context.FacultyEnroll.Where(fe => specializares.Contains(fe.Specializare))
                .Select(fe => fe.Student).ToList();*/
        }

        public HashSet<Student> FilterStudentsByDepartmentName(string departmentName)
        {
            List<ICollection<Specializare>> specializares = context.Department.Where(d => d.Name == departmentName)
                .Select(d => d.Specializares).ToList();

            HashSet<Student> allStudents = new HashSet<Student>();
            foreach (var s in specializares){
                allStudents.Concat(context.FacultyEnroll.Where(fe => s.Contains(fe.Specializare))
                                .Select(fe => fe.Student).ToList());
            }
            return allStudents;
        }

        public List<Student> FilterStudentsByAn(string an)
        {
            return context.Student.Where(s => s.An == an).Select(s => s).ToList();
        }

        public List<Student> FilterStudentsByGroup(string groupName)
        {
            return context.FacultyEnroll.Where(fe => fe.Group.GroupName == groupName)
                .Select(fe => fe.Student).ToList();
        }
    }
}
