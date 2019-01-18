using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AcademicInfoServerEF22EF22.Models
{
    public class GradesToDiscipline
    {
        [Required, Key]
        public Int32 Id { get; set; }

        [Required]
        public virtual Discipline Discipline { get; set; }

         public virtual ICollection<Grade> Grades { get; set; }
    }
}
