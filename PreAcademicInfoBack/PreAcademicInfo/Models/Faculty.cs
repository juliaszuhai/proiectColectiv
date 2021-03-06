﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PreAcademicInfo.Models
{
    public class Faculty
    {
        [Required, Key]
        public Int32 Id { get; set; }

        [Required]
        public String NumeUniveristate { get; set; }

        [Required]
        public String Nume { get; set; }

        [Required]
        public String Adresa { get; set; }

        public ICollection<Department> Departments { get; set; }
    }
}
