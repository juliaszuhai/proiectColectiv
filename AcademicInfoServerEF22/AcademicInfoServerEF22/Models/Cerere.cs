using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AcademicInfoServerEF22EF22.Models
{
    public enum CerereType { BURSA }
    public class Cerere
    {
        [Required, Key]
        public Int32 Id { get; set; }

        [Required]
        public String NumeStudent { get; set; }

        [Required]
        public String PrenumeStudent { get; set; }

        [Required]
        public CerereType Type { get; set; }

        [Required]
        public Int32 An { get; set; }

        [Required]
        public byte[] Cerere_bytes { get; set; }
    }
}