using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PreAcademicInfo.Models
{
    public class Admin : User
    {
        [Required]
        public Int32 Adresa { get; set; }

        public ICollection<Specializare> Specializares { get; set; }
    }
}
