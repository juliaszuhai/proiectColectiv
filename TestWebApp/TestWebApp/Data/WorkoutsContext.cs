using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace TestWebApp.Models
{
    public class WorkoutsContext : DbContext
    {
        public WorkoutsContext (DbContextOptions<WorkoutsContext> options)
            : base(options)
        {
        }

        public DbSet<TestWebApp.Models.Workout> Workout { get; set; }
    }
}
