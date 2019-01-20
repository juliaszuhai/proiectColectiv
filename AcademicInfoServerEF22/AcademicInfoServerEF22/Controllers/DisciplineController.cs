using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AcademicInfoServerEF22EF22.Models;

namespace AcademicInfoServerEF22EF22.Controllers
{
    [Produces("application/json")]
    [Route("api/Discipline")]
    public class DisciplineController : Controller
    {
        private readonly AcademicInfoContext _context;

        public DisciplineController(AcademicInfoContext context)
        {
            _context = context;
        }

        // GET: api/Discipline
        [HttpGet]
        public IEnumerable<Discipline> GetDiscipline()
        {
            return _context.Discipline;
        }

        // GET: api/Discipline/<teacherUsername>
        [HttpGet("materii/teacher/{teacherUsername}")]
        public IActionResult GetTeacherDisciplines([FromRoute] string teacherUsername)
        {
            // Get all disciplines names that belong to a teacher
            List<string> disciplines = new List<string>();
            disciplines = _context.Teacher.Where(
                t => t.Username.Equals(teacherUsername)
            ).FirstOrDefault().DisciplinesHolded.Select(
                d => d.Nume
            ).ToList();

            // Return the list of disciplines
            return Json(disciplines);
        }

        [HttpGet("materii/student/{username}")]
        public IActionResult GetmateriiEnrolled([FromRoute] string username)
        {
            Student student = _context.Student.Where(s => s.Username.Equals(username)).FirstOrDefault();
            // Create the inner dictionary for the student's info
            var studentDict = new Dictionary<string, object>();

            // Create a list in which we store all the grades that we get for the students
            List<string> gradesList = new List<string>();

            // For each grade that we get
            foreach (var m in student.Grades.Select(s => s.Discipline.Nume).ToList())
            {
                // Create an inner inner dictionary for his grades
                var gradeDict = new Dictionary<string, string>();

                // Append the inner inner dictionary to the list of grades
                gradesList.Add(m);
            }
            
            // Return the response
            return Json(gradesList);
        }


        // PUT: api/Discipline/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDiscipline([FromRoute] string id, [FromBody] Discipline discipline)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != discipline.Cod)
            {
                return BadRequest();
            }

            _context.Entry(discipline).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DisciplineExists(id))
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

        // POST: api/Discipline
        [HttpPost]
        public async Task<IActionResult> PostDiscipline([FromBody] Discipline discipline)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Discipline.Add(discipline);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDiscipline", new { id = discipline.Cod }, discipline);
        }

        [HttpPost("prezenteLab/{materie}/{usernameStudent}/{noAttendance}")]
        public IActionResult PostPrezenteLab([FromRoute] string materie, [FromRoute] string usernameStudent,
                                            [FromRoute] string noAttendance)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var grade = _context.Student.Where(s => s.Username.Equals(usernameStudent)).FirstOrDefault().Grades
                .Where(gtd => gtd.Discipline.Nume.Equals(materie)).FirstOrDefault();
            grade.AttendanceLab = int.Parse(noAttendance);
           _context.SaveChangesAsync();

            return Ok();
        }

        [HttpPost("prezenteSeminar/{materie}/{usernameStudent}/{noAttendance}")]
        public IActionResult PostPrezenteSeminar([FromRoute] string materie, [FromRoute] string usernameStudent,
                                            [FromRoute] string noAttendance)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var grade = _context.Student.Where(s => s.Username.Equals(usernameStudent)).FirstOrDefault().Grades
                .Where(gtd => gtd.Discipline.Nume.Equals(materie)).FirstOrDefault();
            grade.AttendanceSeminary = int.Parse(noAttendance);
            _context.SaveChangesAsync();

            return Ok();
        }

        // DELETE: api/Discipline/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDiscipline([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var discipline = await _context.Discipline.SingleOrDefaultAsync(m => m.Cod == id);
            if (discipline == null)
            {
                return NotFound();
            }

            _context.Discipline.Remove(discipline);
            await _context.SaveChangesAsync();

            return Ok(discipline);
        }

        private bool DisciplineExists(string id)
        {
            return _context.Discipline.Any(e => e.Cod == id);
        }

        [HttpGet("listDisciplines/{specializare}/{an}/{semestru}")]
        public IActionResult GetAvailableDisciplines([FromRoute] string specializare, [FromRoute] string an, [FromRoute] string semestru)
        {
            List<Discipline> disciplines = null;
            if (specializare != "" && !an.Equals("0") && !semestru.Equals("0"))
            {
                disciplines = _context.Discipline.Where(d => d.Specializare.Nume.Equals(specializare) &&
                                           d.An.ToString().Equals(an) &&
                                           d.Semestru.ToString().Equals(semestru)).ToList();
            }
            else if (specializare != "")
            {
                if (!an.Equals("0") && semestru.Equals("0"))
                {
                    disciplines = _context.Discipline.Where(d => d.Specializare.Nume.Equals(specializare) &&
                                            d.An.ToString().Equals(an)).ToList();
                }
                if (!semestru.Equals("0") && an.Equals("0"))
                {
                    disciplines = _context.Discipline.Where(d => d.Specializare.Nume.Equals(specializare) &&
                                            d.Semestru.ToString().Equals(semestru)).ToList();
                }
                if (semestru.Equals("0") && an.Equals("0"))
                {
                    disciplines = _context.Discipline.Where(d => d.Specializare.Nume.Equals(specializare)).ToList();
                }
            }
            List<Dictionary<string, string>> response = new List<Dictionary<string, string>>();
            foreach (var d in disciplines)
            {
                Dictionary<string, string> dict = new Dictionary<string, string>();
                dict.Add("An", d.An.ToString());
                dict.Add("semestru", d.Semestru.ToString());
                dict.Add("nume", d.Nume);
                dict.Add("type", d.Type.ToString());
                dict.Add("codMaterie", d.Cod);
                dict.Add("nrCredite", d.Credite.ToString());
                dict.Add("locuriDisponibile", "0");
                dict.Add("locuriOcupate", "0");

                response.Add(dict);
            }

            return Ok(response);
        }
    }
}