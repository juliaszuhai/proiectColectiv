using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AcademicInfoServer.Models
{
    public class Student : User
    {
        [Required]
        public Int32 NumarMatricol { get; set; }

        [Required]
        public String CNP { get; set; }

        [Required]
        public String InitialaParinte { get; set; }

        [Required]
        public Boolean Active { get; set; }

        [Required]
        public String Generatie { get; set; }

        [Required]
        public String An { get; set; }
        
        public ICollection<FacultyEnroll> FacultiesEnrolled { get; set; }
        public ICollection<GradesToDiscipline> Grades { get; set; }

    }
}
