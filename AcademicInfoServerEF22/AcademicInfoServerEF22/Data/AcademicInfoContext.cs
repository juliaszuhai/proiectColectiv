using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AcademicInfoServerEF22EF22.Models;

namespace AcademicInfoServerEF22EF22.Models
{
    public class AcademicInfoContext : DbContext
    {
        public AcademicInfoContext (DbContextOptions<AcademicInfoContext> options)
            : base(options)
        {
            
        }
        public DbSet<AcademicInfoServerEF22EF22.Models.Admin> Admin { get; set; }

        public DbSet<AcademicInfoServerEF22EF22.Models.Department> Department { get; set; }

        public DbSet<AcademicInfoServerEF22EF22.Models.Discipline> Discipline { get; set; }

        public DbSet<AcademicInfoServerEF22EF22.Models.Faculty> Faculty { get; set; }

        public DbSet<AcademicInfoServerEF22EF22.Models.FacultyEnroll> FacultyEnroll { get; set; }

        public DbSet<AcademicInfoServerEF22EF22.Models.Grade> Grade { get; set; }

        public DbSet<AcademicInfoServerEF22EF22.Models.GradesToDiscipline> GradeToDiscipline { get; set; }

        public DbSet<AcademicInfoServerEF22EF22.Models.Group> Group { get; set; }

        public DbSet<AcademicInfoServerEF22EF22.Models.Specializare> Specializare { get; set; }


        public DbSet<AcademicInfoServerEF22EF22.Models.Teacher> Teacher { get; set; }

        public DbSet<AcademicInfoServerEF22EF22.Models.Student> Student { get; set; }

    }
}
