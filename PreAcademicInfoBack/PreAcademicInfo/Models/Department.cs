using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PreAcademicInfo.Models
{
    public class Department
    {
        [Required]
        public Faculty Faculty { get; set; }

        [Required]
        public String Name { get; set; }

        [Required]
        public Teacher ProDecan { get; set; }

        public ICollection<Specializare> Specializares { get; set; }
    }
}
