using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace AcademicInfoServerEF22EF22.Models
{
    public class ContractToDiscipline
    {
        [Required, Key]
        public Int32 Id { get; set; }

        [Required]
        public virtual Discipline Discipline { get; set; }

        [Required]
        public virtual Contract Contract { get; set; }

    }
}
