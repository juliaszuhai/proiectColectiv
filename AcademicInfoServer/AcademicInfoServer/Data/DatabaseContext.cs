using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace AcademicInfoServer.Models
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext (DbContextOptions<DatabaseContext> options)
            : base(options)
        {
        }
        public DbSet<AcademicInfoServer.Models.Admin> Admin { get; set; }

        public DbSet<AcademicInfoServer.Models.Department> Department { get; set; }

        public DbSet<AcademicInfoServer.Models.Discipline> Discipline { get; set; }

        public DbSet<AcademicInfoServer.Models.Faculty> Faculty { get; set; }

        public DbSet<AcademicInfoServer.Models.FacultyEnroll> FacultyEnroll { get; set; }

        public DbSet<AcademicInfoServer.Models.Grade> Grade { get; set; }

        public DbSet<AcademicInfoServer.Models.GradesToDiscipline> GradeToDiscipline { get; set; }

        public DbSet<AcademicInfoServer.Models.Group> Group { get; set; }

        public DbSet<AcademicInfoServer.Models.Specializare> Specializare { get; set; }


        public DbSet<AcademicInfoServer.Models.Teacher> Teacher { get; set; }

        public DbSet<AcademicInfoServer.Models.Student> Student { get; set; }
    }
}
