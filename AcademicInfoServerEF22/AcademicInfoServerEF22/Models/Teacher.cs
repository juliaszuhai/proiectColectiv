using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AcademicInfoServerEF22EF22.Models
{
    public class Teacher : User
    {
        public virtual ICollection<Discipline> DisciplinesHolded { get; set; }

        public string PictureURL { get; set; }

        public string Description { get; set; }
    }
}
