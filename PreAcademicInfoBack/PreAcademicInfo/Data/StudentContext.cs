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

        public DbSet<PreAcademicInfo.Models.Student> Student { get; set; }

        public DbSet<PreAcademicInfo.Models.Teacher> Teacher { get; set; }
    }
}
