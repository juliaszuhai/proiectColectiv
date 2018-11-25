using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace PreAcademicInfo.Models
{
    public class DepartmentsContext : DbContext
    {
        public DepartmentsContext (DbContextOptions<DepartmentsContext> options)
            : base(options)
        {
        }

        public DbSet<PreAcademicInfo.Models.Department> Departments { get; set; }
    }
}
