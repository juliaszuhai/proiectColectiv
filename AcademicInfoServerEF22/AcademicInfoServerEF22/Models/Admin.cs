using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AcademicInfoServerEF22EF22.Models
{
    public class Admin : User
    {
        [Required]
        public String Adresa { get; set; }

        public virtual ICollection<Specializare> Specializares { get; set; }
    }
}
