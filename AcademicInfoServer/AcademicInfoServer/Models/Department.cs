using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AcademicInfoServer.Models
{
    public class Department
    {
        [Required,Key]
        public Int32 Id { get; set; }

        [Required]
        public String Name { get; set; }
        
        //[Required]
        //public Faculty Faculty { get; set; }

        public ICollection<Specializare> Specializares { get; set; }
    }
}
