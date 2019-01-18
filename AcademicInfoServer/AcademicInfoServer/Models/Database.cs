using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AcademicInfoServer.Models
{
    public class Database
    {
        public int Id { get; set; }

        public DateTimeOffset Date { get; set; }

        public string description { get; set; }
    }
}
