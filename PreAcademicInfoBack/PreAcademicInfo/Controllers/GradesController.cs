using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PreAcademicInfo.Models;
namespace PreAcademicInfo.Controllers
{
    [Produces("application/json")]
    [Route("api/Grades")]
    public class GradesController : Controller
    {
        private readonly StudentContext _context;

        public GradesController(StudentContext context)
        {
            _context = context;
        }

        // GET: api/Grades
        [HttpGet]
        public IEnumerable<Grade> GetGrade()
        {
            return _context.Grade;
        }

        // GET: api/Grades/5
        //[HttpGet("{id}")]
        //public async Task<IActionResult> GetGrade([FromRoute] int id)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    var grade = await _context.Grade.SingleOrDefaultAsync(m => m.Id == id);

        //    if (grade == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(grade);
        //}

        // GET: api/Grades/username
        [HttpGet("{username}")]
        public IActionResult GetGradesOfStudent([FromRoute] string username)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            List<Grade> grades = _context.Grade.Where(g => g.Student.Username.Equals(username)).ToList();
            List<GradeJSON> gradesJSON = new List<GradeJSON>();
            foreach(var g in grades)
            {

                //GradeJSON gJSON = new GradeJSON(g.Discipline.Nume, g.Discipline.An.ToString(), g.Discipline.Semestru.ToString(),
                //              g.DataNotei, g.Discipline.Cod, g.GradeValue.ToString(), g.Discipline.Specializare.ToString());

                //until we fix binding object problem:
                ////////////////////////////////////////////////////
                Discipline d = new Discipline()
                {
                    Type = DisciplineType.OBLIGATORIU,
                    Cod = "MLE5555",
                    Nume = "Baze de date distrb.",
                    Credite = 6,
                    An = 2,
                    Semestru = 2,
                    
                };
                Specializare sp = _context.Specializare.FirstOrDefault();
                d.Specializare = sp;
                Teacher t = _context.Teacher.FirstOrDefault();
                d.Teacher = t;
                GradeJSON gJSON = new GradeJSON(d.Nume, d.An.ToString(), d.Semestru.ToString(),
                                "2018-05-06", d.Cod, g.GradeValue.ToString(), d.Specializare.ToString());
                ////////////////////////////////////////////////////

                gradesJSON.Add(gJSON);
            }

            if (gradesJSON.Count == 0)
            {
                return NotFound();
            }

            //var serializer = new JavaScriptSerializer();
            //var serializedResult = serializer.Serialize(gradesJSON);
            return Ok(gradesJSON);
        }

        public class GradeJSON
        {
            string numeMaterie, an, semestru, dataPromovarii, codMaterie, nota, specializare;

            public GradeJSON(string numeMaterie, string an, string semestru, string dataPromovarii, string codMaterie, string nota,string specializare)
            {
                this.numeMaterie = numeMaterie;
                this.an = an;
                this.semestru = semestru;
                this.dataPromovarii = dataPromovarii;
                this.codMaterie = codMaterie;
                this.nota = nota;
                this.specializare = specializare;
            }
        }


        // PUT: api/Grades/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGrade([FromRoute] int id, [FromBody] Grade grade)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != grade.Id)
            {
                return BadRequest();
            }

            _context.Entry(grade).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GradeExists(id))
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

        // POST: api/Grades
        [HttpPost]
        public async Task<IActionResult> PostGrade([FromBody] Grade grade)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Grade.Add(grade);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGrade", new { id = grade.Id }, grade);
        }

        // DELETE: api/Grades/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGrade([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var grade = await _context.Grade.SingleOrDefaultAsync(m => m.Id == id);
            if (grade == null)
            {
                return NotFound();
            }

            _context.Grade.Remove(grade);
            await _context.SaveChangesAsync();

            return Ok(grade);
        }

        private bool GradeExists(int id)
        {
            return _context.Grade.Any(e => e.Id == id);
        }
    }
}