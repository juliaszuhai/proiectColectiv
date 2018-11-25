using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace PreAcademicInfo.Models
{
    public class SpecializariContext : DbContext
    {
        public SpecializariContext (DbContextOptions<SpecializariContext> options)
            : base(options)
        {
        }

        public DbSet<PreAcademicInfo.Models.Specializare> Specializare { get; set; }
    }
}
