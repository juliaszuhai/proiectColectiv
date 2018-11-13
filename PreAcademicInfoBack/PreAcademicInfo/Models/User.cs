using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Cryptography;
using BCrypt.Net;

namespace PreAcademicInfo.Models
{

    public enum UserType { TEACHER,STUDENT,ADMIN};
    public class User
    {
        [Required,Key]
        public String Username { get; set; }

        
        [Required]
        public String Password
        {
            get; set;
        }

        [Required]
        public String Salt
        {
            get; set;
        }

        [Required]
        public String Email { get; set; }

        [Required]
        public String Nume { get; set; }

        [Required]
        public String Prenume { get; set; }

        [Required, MaxLength(14, ErrorMessage = "Numar de telefon prea lung"), MinLength(10)]
        public Int32 NumarTelefon { get; set; }

        [Required]
        public UserType UserType { get; set; }
        
    }
}
