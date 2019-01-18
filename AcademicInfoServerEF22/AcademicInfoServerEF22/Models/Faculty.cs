using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AcademicInfoServerEF22EF22.Models
{
    public class Faculty
    {
        [Required, Key]
        public Int32 Id { get; set; }

        [Required]
        public String NumeUniveristate { get; set; }

        [Required]
        public String Nume { get; set; }

        [Required]
        public String Adresa { get; set; }

         public virtual ICollection<Department> Departments { get; set; }
    }
}
