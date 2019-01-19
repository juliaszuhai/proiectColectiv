using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AcademicInfoServer.Models;
namespace AcademicInfoServer.Controllers
{
    [Produces("application/json")]
    [Route("api/Grades")]
    public class GradesController : Controller
    {
        private readonly DatabaseContext _context;

        public GradesController(DatabaseContext context)
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

            //List<Grade> grades = _context.Grade.Where(g => g.Student.Username.Equals(username)).ToList();
            //List<GradeJSON> gradesJSON = new List<GradeJSON>();
            //foreach(var g in grades)
            //{

            //    //GradeJSON gJSON = new GradeJSON(g.Discipline.Nume, g.Discipline.An.ToString(), g.Discipline.Semestru.ToString(),
            //    //              g.DataNotei, g.Discipline.Cod, g.GradeValue.ToString(), g.Discipline.Specializare.ToString());

            //    //until we fix binding object problem:
            //    ////////////////////////////////////////////////////
            //    Discipline d = new Discipline()
            //    {
            //        Type = DisciplineType.OBLIGATORIU,
            //        Cod = "MLE5555",
            //        Nume = "Baze de date distrb.",
            //        Credite = 6,
            //        An = 2,
            //        Semestru = 2,
                    
            //    };
            //    Specializare sp = _context.Specializare.FirstOrDefault();
            //    d.Specializare = sp;
            //    Teacher t = _context.Teacher.FirstOrDefault();
            //    d.Teacher = t;
            //    GradeJSON gJSON = new GradeJSON(d.Nume, d.An.ToString(), d.Semestru.ToString(),
            //                    "2018-05-06", d.Cod, g.GradeValue.ToString(), d.Specializare.ToString());
            //    ////////////////////////////////////////////////////

            //    gradesJSON.Add(gJSON);
            //}

            //if (gradesJSON.Count == 0)
            //{
            //    return NotFound();
            //}

            ////var serializer = new JavaScriptSerializer();
            ////var serializedResult = serializer.Serialize(gradesJSON);
            return Ok();
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

        // GET: api/Grades/Statistics/2018/Info-Engleza
        [HttpGet("Statistics/{year}/{specialization}")]
        public async Task<IActionResult> GradeBuckets([FromRoute] string year, [FromRoute] string specialization)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            List<double> grades = GetGradesByYearAndSpecialization(year, specialization);
            
            
            //Put into buckets 0-5, 5-6, 6-7, 7-8, 8-9, 9-10, 10
            List<int> nrGradesByBucket = new List<int>(new int[] { 0, 0, 0, 0, 0, 0, 0 });
            foreach(double grade in grades)
            {
                if (grade == 10)
                    nrGradesByBucket[0]++;
                if (grade >= 9 && grade < 10)
                    nrGradesByBucket[1]++;
                if (grade >= 8 && grade < 9)
                    nrGradesByBucket[2]++;
                if (grade >= 7 && grade < 8)
                    nrGradesByBucket[3]++;
                if (grade >= 6 && grade < 7)
                    nrGradesByBucket[4]++;
                if (grade >= 5 && grade < 6)
                    nrGradesByBucket[5]++;
                if (grade < 5)
                    nrGradesByBucket[6]++;
            }

            return Ok(nrGradesByBucket);
        }

        private List<double> GetGradesByYearAndSpecialization(string year, string specialization)
        {
            List<double> grades = new List<double>();

            //Get all students enrolled to given specialization
            List<Student> students = _context.Student.Where(student => student.FacultiesEnrolled.Any(fe => fe.Specializare.Nume == specialization)).ToList();

            //Get all students from given year
            students = students.Where(student => (student.An == year)).ToList();

            //For each student in that specialization and year
            foreach (Student student in students)
            {
                //Get grades to discipline for that student
                List<GradesToDiscipline> studentGradesToDisciplines = student.Grades.ToList();
                double sumFinalGrades = 0;
                studentGradesToDisciplines.ForEach(
                    sGD => 
                    {
                        //Get final grade at a discipline and add it to sum
                        Grade grade = sGD.Grades.Where(g => g.Type == GradeType.FINAL).First();
                        sumFinalGrades += grade.GradeValue;

                    });
                //Mean of final grades for that student
                double meanFinalGrades = sumFinalGrades / studentGradesToDisciplines.Count;

                //Add it to the list of final grades
                grades.Add(meanFinalGrades);
            }

            //List<Student> students = _context.Student
            //    .Join<Student, FacultyEnroll, Student, KeyValuePair<Student, Specializare>>(
            //        _context.FacultyEnroll.ToList(),
            //        student => student,
            //        facultyEnroll => facultyEnroll.Student,
            //        (student, facultyEnroll) => new KeyValuePair<Student, Specializare>(student, facultyEnroll.Specializare))
            //    .Where(ss => (ss.Key.An == year && ss.Value.Nume == specialization))
            //    .Select(ss => ss.Key).ToList();

            //foreach (Student student in students)
            //{
            //      List<Grade> gradesPerStudent = _context.Grade
            //          .Where(grade => (grade.Student.NumarMatricol == student.NumarMatricol && grade.Type == GradeType.FINAL)).ToList();

            //      gradesPerStudent.ForEach(grade => grades.Add(grade));
            //}

            return grades;
        }
    }
}