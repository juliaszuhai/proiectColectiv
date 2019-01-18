using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AcademicInfoServer.Models
{
    public class Admin : User
    {
        [Required]
        public String Adresa { get; set; }

        public ICollection<Specializare> Specializares { get; set; }
    }
}
