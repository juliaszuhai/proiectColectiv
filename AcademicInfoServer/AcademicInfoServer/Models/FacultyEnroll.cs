using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AcademicInfoServer.Models
{
    public class FacultyEnroll
    {
        [Required, Key]
        public Int32 Id { get; set; }

        [Required]
        public Specializare Specializare { get; set; }

        //[Required, ForeignKey("StudentId")]
        //public Student Student { get; set; }

        [Required,ForeignKey("GroupId")]
        public Group Group { get; set; }

    }
}
