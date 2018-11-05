using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PreAcademicInfo.Models
{
    public class FacultyEnroll
    {
        [Required]
        public Specializare Specializare { get; set; }

        [Required,ForeignKey("GroupId")]
        public Group Group { get; set; }

    }
}
