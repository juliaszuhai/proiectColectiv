using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace PreAcademicInfo.Models
{
    public class DisciplineContext : DbContext
    {
        public DisciplineContext (DbContextOptions<DisciplineContext> options)
            : base(options)
        {
        }

        public DbSet<PreAcademicInfo.Models.Discipline> Discipline { get; set; }
    }
}
