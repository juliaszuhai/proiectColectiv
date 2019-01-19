using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace AcademicInfoServerEF22EF22.Models
{
    public class Contract
    {
        [Required, Key]
        public Int32 Id { get; set; }

        [Required]
        public virtual Student Student { get; set; }

        public virtual ICollection<ContractToDiscipline> Disciplines { get; set; }


    }
}
