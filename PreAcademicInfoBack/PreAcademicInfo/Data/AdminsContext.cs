using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace PreAcademicInfo.Models
{
    public class AdminsContext : DbContext
    {
        public AdminsContext (DbContextOptions<AdminsContext> options)
            : base(options)
        {
        }

        public DbSet<PreAcademicInfo.Models.Admin> Admin { get; set; }
    }
}
