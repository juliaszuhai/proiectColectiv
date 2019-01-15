using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PreAcademicInfo.Models;
using System.Security.Cryptography;
using BCrypt.Net;
using Microsoft.AspNetCore.Cors;

namespace PreAcademicInfo.Controllers
{
    [ProducesResponseType(201)]
    [ProducesResponseType(400)]
    [Produces("application/json")]
    [Consumes("application/json")]
    [Route("api/Students")]
    
    public class StudentsController : Controller
    {
        private readonly StudentContext _context;

        private static RNGCryptoServiceProvider rngCsp = new RNGCryptoServiceProvider();
        

        public StudentsController(StudentContext context)
        {
            _context = context;
            //PopulateDatabase();
        }

        public void PopulateDatabase()
        {

            byte[] saltNumber = new byte[10];
            rngCsp.GetBytes(saltNumber);
            String saltString = System.Text.Encoding.Default.GetString(saltNumber);
            String password = BCrypt.Net.BCrypt.HashPassword(saltString + "pass");
            _context.Student.Add(new Student()
            {
                Username = "andi",
                NumarMatricol = 2000,
                Password = password,
                Salt = saltString,
                Email = "aaie2000@scs.ubbcluj.ro",
                Nume = "Abrudean",
                Prenume = "Andrei",
                NumarTelefon = "0711111110",
                CNP = "1960000000000",
                InitialaParinte = "A",
                Active = true,
                Generatie = "2016",
                An = "3",
                UserType = UserType.STUDENT
            });
            _context.SaveChanges();
        }

        // GET: api/Students
        [HttpGet]
        public IEnumerable<Student> GetStudent()
        {
            //PopulateDatabase();
            return _context.Student;
        }

        // GET: api/Students
        [HttpGet("{materie}/{grupa}/{tipNota}")]
        public IEnumerable<Student> GetStudent([FromRoute] string materie, [FromRoute] string grupa, [FromRoute] string tipNota)
        {

            return _context.Student;
        }

        // GET: api/Students/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetStudent([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var student = await _context.Student.SingleOrDefaultAsync(m => m.Username == id);

            if (student == null)
            {
                return NotFound();
            }

            return Ok(student);
        }

        [HttpGet("{an}")]
        public IEnumerable<Student> GetStudentsByYear([FromRoute] string an)
        {
            return _context.Student.Where(student => student.An == an);
        }


        // PUT: api/Students/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStudent([FromRoute] string id, [FromBody] Student student)
        {
            if (!ModelState.IsValid)
            {
                Console.WriteLine("nu-i bine model");
                return BadRequest(ModelState);
            }

            if (id != student.Username)
            {
                Console.WriteLine("nu-i bine username");

                return BadRequest();
            }

            _context.Entry(student).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Students
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] JStudent student_)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            byte[] saltNumber = new byte[10];
            rngCsp.GetBytes(saltNumber);
            String saltString = System.Text.Encoding.Default.GetString(saltNumber);
            String password = BCrypt.Net.BCrypt.HashPassword(saltString + "pass");
            Student student = new Student()
            {
                Nume = student_.nume,
                InitialaParinte = student_.initiale,
                NumarMatricol = int.Parse(student_.nrMatricol),
                NumarTelefon = student_.telefon,
                Active = true,
                An = "1",
                Email = student_.email,
                Generatie = DateTime.Now.Year.ToString(),
                UserType = UserType.STUDENT,
                Username = student_.username,
                Password = password,
                Salt = saltString,
                CNP = student_.cnp,
                Prenume = student_.prenume
            };
             _context.Student.Add(student);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStudent", new { id = student.Username }, student);
        }

        // DELETE: api/Students/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var student = await _context.Student.SingleOrDefaultAsync(m => m.Username == id);
            if (student == null)
            {
                return NotFound();
            }

            _context.Student.Remove(student);
            await _context.SaveChangesAsync();

            return Ok(student);
        }

        private bool StudentExists(string id)
        {
            return _context.Student.Any(e => e.Username == id);
        }

        public class JStudent
        {
            public string nume { get; set; }
            public string prenume { get; set; }
            public string email { get; set; }
            public string cnp { get; set; }
            public string nrMatricol { get; set; }
            public string username { get; set; }
            public string telefon { get; set; }
            public string initiale { get; set; }

            internal Student GetStudent() => new Student
            {
                NumarMatricol = int.Parse(nrMatricol),
                CNP = cnp,
                InitialaParinte = initiale,
                Active = true,
                Generatie = DateTime.Now.Year.ToString(),
                An = "1",
                Password = cnp,
                Username =username,
                NumarTelefon=telefon,
                UserType = UserType.STUDENT,
                Email = email,
                Nume = nume,
                Prenume = prenume
        };
        }
    }
}