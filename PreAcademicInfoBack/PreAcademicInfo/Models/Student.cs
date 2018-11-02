using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PreAcademicInfo.Models
{
    public class Student
    {
        [Required,Key]
        public Int32 NumarMatricol { get; }

        [Required]
        public String CNP { get; }

        [Required]
        public String Nume { get; set; }

        [Required]
        public String Prenume { get; set; }

        [Required]
        public String InitialaParinte { get; set; }

        [Required]
        public String Email { get; set; }

        [Required,MaxLength(14, ErrorMessage= "Numar de telefon prea lung"),MinLength(10)]
        public String NumarTelefon { get; set; }
             
        [Required]
        public String An { get; set; }
        
        public ICollection<FacultyEnroll> FacultiesEnrolled { get; set; }







    }
}
