using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AcademicInfoServerEF22EF22.Models
{
    public class FacultyEnroll
    {
        [Required, Key]
        public Int32 Id { get; set; }

        [Required]
        public virtual Specializare Specializare { get; set; }

        //[Required, ForeignKey("StudentId")]
        //public Student Student { get; set; }

        [Required,ForeignKey("GroupId")]
        public virtual Group Group { get; set; }

    }
}
