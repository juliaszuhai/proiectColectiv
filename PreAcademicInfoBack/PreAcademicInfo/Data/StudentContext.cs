using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace PreAcademicInfo.Models
{
    public class StudentContext : DbContext
    {
        public StudentContext (DbContextOptions<StudentContext> options)
            : base(options)
        {
        }
        public DbSet<PreAcademicInfo.Models.Admin> Admin { get; set; }

        public DbSet<PreAcademicInfo.Models.Department> Department { get; set; }

        public DbSet<PreAcademicInfo.Models.Discipline> Discipline { get; set; }

        public DbSet<PreAcademicInfo.Models.Faculty> Faculty { get; set; }

        public DbSet<PreAcademicInfo.Models.FacultyEnroll> FacultyEnroll { get; set; }

        public DbSet<PreAcademicInfo.Models.Grade> Grade { get; set; }

        public DbSet<PreAcademicInfo.Models.GradesToDiscipline> GradeToDiscipline { get; set; }

        public DbSet<PreAcademicInfo.Models.Group> Group { get; set; }

        public DbSet<PreAcademicInfo.Models.Specializare> Specializare { get; set; }


        public DbSet<PreAcademicInfo.Models.Teacher> Teacher { get; set; }

        public DbSet<PreAcademicInfo.Models.Student> Student { get; set; }

        public DbSet<PreAcademicInfo.Models.Teacher> Teacher { get; set; }
    }
}
