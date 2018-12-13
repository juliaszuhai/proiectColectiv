using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PreAcademicInfo.Models
{
    public class GradesToDiscipline
    {
        [Required, Key]
        public Int32 Id { get; set; }

        [Required]
        public Discipline Discipline { get; set; }

        public ICollection<Grade> Grades { get; set; }
    }
}
