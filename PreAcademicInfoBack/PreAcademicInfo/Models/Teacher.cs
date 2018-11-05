using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PreAcademicInfo.Models
{
    public class Teacher : User
    {
        public ICollection<Discipline> DisciplinesHolded { get; set; }
    }
}
