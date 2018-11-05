using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PreAcademicInfo.Models
{
    public class Group
    {
        [Required, Key]
        public Int32 Id { get; set; }

        [Required]
        public String NumeGrupa { get; set; }

        public ICollection<Student> Students { get; set; }
    }
}
