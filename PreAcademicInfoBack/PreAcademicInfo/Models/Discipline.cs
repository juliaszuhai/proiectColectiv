using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PreAcademicInfo.Models
{
    public class Discipline
    {
        [Required]
        public String Nume { get; set; }

        [Required]
        public int Credite { get; set; }

        [Required]
        public Int32 An { get; set; }

        [Required]
        public Teacher Teacher { get; set; }

    }
}
