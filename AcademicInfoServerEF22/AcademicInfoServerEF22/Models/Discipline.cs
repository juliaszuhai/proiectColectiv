﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AcademicInfoServerEF22EF22.Models
{
    public enum DisciplineType { OBLIGATORIU, OPTIONAL, FACULTATIV }
    public class Discipline
    {
        [Required]
        public DisciplineType Type  { get; set; }

        [Required]
        public virtual Specializare Specializare { get; set; }

        [Required,Key]
        public String Cod { get; set; }

        [Required]
        public String Nume { get; set; }

        [Required]
        public Int32 Credite { get; set; }

        [Required]
        public Int32 An { get; set; }

        [Required]
        public Int32 Semestru { get; set; }

        //[Required]
        //public Teacher Teacher { get; set; }

        public Int32 LocuriDisponibile { get; set; }

        public Int32 RequiredLabAttendance { get; set; }

        public Int32 RequiredSeminaryAttendance { get; set; }

    }
}
