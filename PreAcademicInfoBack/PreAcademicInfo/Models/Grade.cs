using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PreAcademicInfo.Models
{
    public enum GradeType { LAB, SEMINAR, EXAMEN, PARTIAL, BONUS, FINAL}
    public class Grade
    {
        [Required, Key]
        public Int32 Id { get; set; }

        [Required]
        public Discipline Discipline { get; set; }

        [Required]
        public Student Student { get; set; }

        [Required]
        public Double GradeValue { get; set; }
        public GradeType Type { get; set; }

        public Int32 PrezenteLab { get; set; }
        public Int32 PrezenteSeminar { get; set; }

    }
}
