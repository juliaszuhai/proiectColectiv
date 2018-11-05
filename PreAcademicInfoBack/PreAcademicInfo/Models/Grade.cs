using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PreAcademicInfo.Models
{
    public enum GradeType { LAB, SEMINAR, EXAMEN, PARTIAL, BONUS}
    public class Grade
    {
        [Required]
        public Discipline Discipline { get; set; }

        [Required]
        public Student Student { get; set; }

        [Required]
        public Double FinalGrade { get; set; }

        public Int32 PrezenteLab { get; set; }
        public Int32 PrezenteSeminar { get; set; }

        public GradeType type { get; set; }
    }
}
