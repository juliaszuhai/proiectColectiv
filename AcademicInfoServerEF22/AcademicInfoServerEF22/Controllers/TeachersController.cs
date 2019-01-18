using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AcademicInfoServerEF22EF22.Models;

namespace AcademicInfoServerEF22EF22.Controllers
{
    [ProducesResponseType(201)]
    [ProducesResponseType(400)]
    [Consumes("application/json")]
    [Produces("application/json")]
    [Route("api/Teachers")]
    public class TeachersController : Controller
    {
        private readonly AcademicInfoContext _context;

        private static RNGCryptoServiceProvider rngCsp = new RNGCryptoServiceProvider();
        
        public TeachersController(AcademicInfoContext context)
        {
            _context = context;
            PopulateDatabase();
        }

        public void PopulateDatabase()
        {
            //Try to retrieve the Teacher with the Username 'tzutzu'
            Teacher t = _context.Teacher.Where(teacher => teacher.Username.Equals("tzutzu")).FirstOrDefault();

            //If he is not present into the DB, then it means we must add him
            if (t == null)
            {
                //Generate salt
                byte[] saltNumber = new byte[10];
                rngCsp.GetBytes(saltNumber);
                String saltString = System.Text.Encoding.Default.GetString(saltNumber);

                //Encrypt password
                String password = BCrypt.Net.BCrypt.HashPassword(saltString + "pass");

                //Add the student 'andi'
                _context.Teacher.Add(new Teacher()
                {
                    Username = "tzutzu",
                    Email = "tzutzu@cs.ubbcluj.ro",
                    NumarTelefon = "0711111128",
                    Nume = "Suciu",
                    Prenume = "Dan Mircea",
                    UserType = UserType.TEACHER,
                    Password = password,
                    Salt = saltString
                });

                //Commit changes to DB
                _context.SaveChanges();
            }
        }

        // GET: api/Teachers
        [HttpGet]
        public IEnumerable<Teacher> GetTeacher()
        {
            return _context.Teacher;
        }

        // GET: api/Teachers/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTeacher([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var teacher = await _context.Teacher.SingleOrDefaultAsync(m => m.Username == id);

            if (teacher == null)
            {
                return NotFound();
            }

            return Ok(teacher);
        }

        // PUT: api/Teachers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTeacher([FromRoute] string id, [FromBody] Teacher teacher)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != teacher.Username)
            {
                return BadRequest();
            }

            _context.Entry(teacher).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TeacherExists(id))
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

        // POST: api/Teachers
        [HttpPost]
        public async Task<IActionResult> PostTeacher([FromBody] JTeacher teacher)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            byte[] saltNumber = new byte[10];
            rngCsp.GetBytes(saltNumber);
            String saltString = System.Text.Encoding.Default.GetString(saltNumber);
            String password = BCrypt.Net.BCrypt.HashPassword(saltString + "pass");
            Teacher teacher1 = new Teacher()
            {
                Nume = teacher.nume,
                NumarTelefon = teacher.numartelefon,
                Email = teacher.email,
                UserType = UserType.TEACHER,
                Username = teacher.username,
                Password = password,
                Salt = saltString,
                Prenume = teacher.prenume
            };
            _context.Teacher.Add(teacher1);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTeacher", new { id = teacher1.Username }, teacher1);
        }

        // DELETE: api/Teachers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTeacher([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var teacher = await _context.Teacher.SingleOrDefaultAsync(m => m.Username == id);
            if (teacher == null)
            {
                return NotFound();
            }

            _context.Teacher.Remove(teacher);
            await _context.SaveChangesAsync();

            return Ok(teacher);
        }

        private bool TeacherExists(string id)
        {
            return _context.Teacher.Any(e => e.Username == id);
        }

        public class JTeacher
        {
            public string nume { get; set; }
            public string prenume { get; set; }
            public string email { get; set; }
            public string username { get; set; }
            public string numartelefon { get; set; }
      

            internal Teacher GetTeacher() => new Teacher
            {
                Password = "pass",
                Username = username,
                NumarTelefon = numartelefon,
                UserType = UserType.TEACHER,
                Email = email,
                Nume = nume,
                Prenume = prenume
            };
        }
    }
    
}