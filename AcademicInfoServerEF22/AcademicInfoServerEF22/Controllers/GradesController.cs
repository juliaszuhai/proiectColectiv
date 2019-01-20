using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AcademicInfoServerEF22EF22.Models;
using AcademicInfoServerEF22.Services;
using System;
namespace AcademicInfoServerEF22EF22.Controllers
{
    [Produces("application/json")]
    [Route("api/Grades")]
    public class GradesController : Controller
    {
        private readonly AcademicInfoContext _context;

        public GradesController(AcademicInfoContext context)
        {
            _context = context;
        }

        // GET: api/Grades
        [HttpGet]
        public IEnumerable<Grade> GetGrade()
        {
            return _context.Grade;
        }

        // POST: api/Grades/percentage
        [HttpPost("percentage")]
        public IActionResult SetInnerandOutterPercentagesForGrades([FromBody] PercentageJSON body)
        {
            // Get all the students that are enrolled to the given discipline
            List<Student> students = _context.Student.Where(
                s => s.Grades.FirstOrDefault().Discipline.Nume.Equals(
                    body.Materie
                )
            ).ToList();

            // For each student
            foreach(var s in students)
            {
                // Get the student's GradeToDiscipline for the respective discipline
                GradesToDiscipline gradeToDiscipline = s.Grades.Where(
                    gtd => gtd.Discipline.Equals(body.Materie)
                ).FirstOrDefault();

                // For each grade
                foreach(var g in gradeToDiscipline.Grades)
                {
                    // Update the inner and outter fields acordingly
                    switch(g.Type.ToString())
                    {
                        case "EXAMEN":
                            if (body.Examen != null)
                            {
                                g.ProcentOuter = 1;
                                g.ProcentInnerType = double.Parse(body.Examen);
                            }
                            break;
                        case "SEMINAR":
                            if (body.Seminar != null)
                            {
                                g.ProcentOuter = 1;
                                g.ProcentInnerType = double.Parse(body.Seminar);
                            }
                            break;
                        case "PARTIAL":
                            if (body.Partial != null)
                            {
                                g.ProcentOuter = 1;
                                g.ProcentInnerType = double.Parse(body.Partial);
                            }
                            break;
                        case "BONUS":
                            if (body.Bonus != null)
                            {
                                g.ProcentOuter = 1;
                                g.ProcentInnerType = double.Parse(body.Bonus);
                            }
                            break;
                        case "LAB":
                            break;
                        case "FINAL":
                            g.ProcentOuter = 1;
                            g.ProcentInnerType = 1;
                            break;
                    }
                }
                // Check if we need to update the lab grades
                if (body.Laborator != null)
                {
                    // Now we update the lab grades by first selecting all the the lab grades of our current student
                    List<Grade> labGrades = gradeToDiscipline.Grades.Where(
                        g => g.Type.ToString().Equals("LAB")
                    // and sort the list of grades after the grade ID
                    ).ToList().OrderBy(g => g.Id).ToList();

                    // Check if the number of lab grades is the same as the one in the DB
                    if (labGrades.Count != body.Laborator.Count)
                    {
                        Dictionary<string, string> err = new Dictionary<string, string>();
                        err.Add("error", String.Format("The number of lab grades sent by the teacher is not the same as the number of lab grades for the student {0}", s.Username));
                        return Json(err);
                    }

                    // For each lab grade update the inner and outter fields acordingly
                    for (int i = 0; i < labGrades.Count; i++)
                    {
                        labGrades[i].ProcentOuter = double.Parse((string)body.Laborator["Outter"]);
                        labGrades[i].ProcentInnerType = double.Parse(((IList<string>)body.Laborator["Inner"])[i]);
                    }
                }
            }

            // Save changes into database
            _context.SaveChanges();

            Dictionary<string, string> success = new Dictionary<string, string>();
            success.Add("success", "The percentages for the provided grade types were successfully updated!");
            return Json(success);
        }

        // GET: api/Grades/<username>
        [HttpGet("{username}")]
        public IActionResult GetGradesOfStudent([FromRoute] string username)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Try to retrieve the student with the given username
            Student s = _context.Student.Where(
                st => st.Username.Equals(username)
            ).FirstOrDefault();

            // If he is not present in the DB return an error message
            if (s == null)
            {
                Dictionary<string, string> error = new Dictionary<string, string>() { };
                error.Add("error", String.Format("There is no student with the username: '{0}'!", username));
                return Json(error);
            }

            //Get the list of GradesToDiscipline for the student with the given username
            List<GradesToDiscipline> gradesToDiscipline = s.Grades.ToList();

            //Create a response List that will store all the grades as dictionaries
            var response = new List<Dictionary<string, string>>();

            //For each gradeToDiscipline
            foreach (var gradeToDicipline in gradesToDiscipline)
            {
                //Retrieve the exam grade
                Grade examGrade = _context.GradeToDiscipline.Where(
                    gtd => gtd.Id.Equals(gradeToDicipline.Id)
                ).FirstOrDefault().Grades.Where(
                    g => g.Type.ToString().Equals("EXAMEN")
                ).FirstOrDefault();

                //Retrieve the final grade
                Grade finalGrade = _context.GradeToDiscipline.Where(
                    gtd => gtd.Id.Equals(gradeToDicipline.Id)
                ).FirstOrDefault().Grades.Where(
                    g => g.Type.ToString().Equals("FINAL")
                ).FirstOrDefault();

                //Create a local dictionary
                var dict = new Dictionary<string, string>();

                //Add the grades informations to the local dictionary
                dict["numeMaterie"] = gradeToDicipline.Discipline.Nume;
                dict["an"] = gradeToDicipline.Discipline.An.ToString();
                dict["semestru"] = gradeToDicipline.Discipline.Semestru.ToString();
                if (examGrade == null)
                    dict["notaExamen"] = "";
                else
                    dict["notaExamen"] = examGrade.GradeValue.ToString();
                if (finalGrade == null)
                {
                    dict["notaFinala"] = "";
                    dict["dataPromovarii"] = ""; 
                }
                else
                {
                    dict["notaFinala"] = finalGrade.GradeValue.ToString();
                    dict["dataPromovarii"] = finalGrade.DataNotei;
                }
                dict["nrCredite"] = gradeToDicipline.Discipline.Credite.ToString();
                dict["codMaterie"] = gradeToDicipline.Discipline.Cod.ToString();
                dict["specializare"] = gradeToDicipline.Discipline.Specializare.Nume;


                //Add the local dictionary to the list of grades
                response.Add(dict);
            }

            //Return the list of grades
            return Json(response);
        }

        // GET: api/Grades/Compute-Final-Grades/<numeMaterie>
        [HttpGet("ComputeFinalGrades/{numeMaterie}")]
        public IActionResult ComputeFinalGrades([FromRoute] string numeMaterie)
        {
            Discipline discipline = _context.Discipline.Where(d => d.Nume.Equals(numeMaterie)).FirstOrDefault();

            if (discipline == null)
            {
                Dictionary<string, string> err = new Dictionary<string, string>();
                err.Add("error", String.Format("There is no discipline called: '{0}'!", numeMaterie));
                return Json(err);
            }

            List<GradesToDiscipline> gradeToDiscipline = _context.GradeToDiscipline.Where(
                gtd => gtd.Discipline.Nume.Equals(numeMaterie)
            ).ToList();

            foreach (var gtd in gradeToDiscipline)
            {
                double finalGrade = 0;

                foreach(var g in gtd.Grades)
                    if (!g.Type.ToString().Equals("LAB"))
                        finalGrade += g.ProcentOuter * g.GradeValue;

                double labGrade = 0;
                foreach (var g in gtd.Grades)
                    if (g.Type.ToString().Equals("LAB"))
                        labGrade += g.ProcentInnerType * g.GradeValue;

                finalGrade += labGrade;
                finalGrade = finalGrade / 100;

                Grade grade = _context.Grade.Where(gr => gr.Type.ToString().Equals("FINAL")).FirstOrDefault();

                if (grade == null)
                {
                    grade = new Grade
                    {
                        GradeValue = finalGrade,
                        DataNotei = DateTime.Now.ToString("dd/MM/yyyy"),
                        Type = GradeType.FINAL,
                        ProcentInnerType = 100,
                        ProcentOuter = 100
                    };

                    gtd.Grades.Add(grade);
                }
                
                else
                {
                    grade.GradeValue = finalGrade;
                    grade.ProcentInnerType = 100;
                    grade.ProcentOuter = 100;
                }                
            }

            _context.SaveChanges();

            List<Student> students = _context.Student.Where(
                    s => s.Grades.Where(
                        g => g.Discipline.Nume.Equals(numeMaterie)
                    ).FirstOrDefault() != null
                ).ToList();

            Service service = new Service(_context);

            service.SendMailToStudents(
                students,
                "Final grades",
                "Hello!\n\nYour teacher posted youe final grade.\nWe hope you passed and we wish you the best of luck :)"
            );

            Dictionary<string, string> response = new Dictionary<string, string>();
            response.Add("success", "The final grades were successfully computed and the students were notified!");
            return Json(response);
        }

        // GET: api/Grades/Statistics/2018/Info-Engleza
        [HttpGet("Statistics/{year}/{specialization}")]
        public IActionResult GradeBuckets([FromRoute] string year, [FromRoute] string specialization)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Service s = new Service (_context);

            List<double> grades = s.GetGradesByYearAndSpecialization(year, specialization);

            //Put into buckets 0-5, 5-6, 6-7, 7-8, 8-9, 9-10, 10
            List<int> nrGradesByBucket = new List<int>(new int[] { 0, 0, 0, 0, 0, 0, 0 });
            foreach (double grade in grades)
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

        [HttpPost]
        public async Task<IActionResult> PostGrade([FromBody] GradeRecived grade)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            GradesToDiscipline gtd = _context.GradeToDiscipline.Where(g => g.Discipline.Nume.Equals(grade.materie)).FirstOrDefault();
            GradeType gt = GradeType.EXAMEN;
            if (grade.tipNota == "Examen final")
            {
                gt = GradeType.EXAMEN;
            }
            else if (grade.tipNota == "Laborator")
            {
                gt = GradeType.LAB;
            }

            if (grade.data == "")
                grade.data = DateTime.Now.ToString("dd/MM/yyyy");
            
            if (grade.idNota == "")
            {
                Grade newGrade = new Grade()
                {
                    GradeValue = double.Parse(grade.grade),
                    DataNotei = grade.data,
                    Type = gt
                };
                gtd.Grades.Add(newGrade);
            }
            else
            {
                Grade recievedGrade = gtd.Grades.Where(g => g.Id == int.Parse(grade.idNota)).FirstOrDefault();
                recievedGrade.GradeValue = double.Parse(grade.grade);
                recievedGrade.DataNotei = grade.data;
            }
            await _context.SaveChangesAsync();

            if (gt == GradeType.EXAMEN)
            {
                List<Student> student = new List<Student>();
                student.Add(_context.Student.Where(s => s.Username.Equals(grade.username)).FirstOrDefault());
                Service service = new Service ( _context );
                service.SendMailToStudents(student, "Exam grade", String.Format("Hello!\n\nYour teacher posted youe exam grade: {0}.\nWe hope you did good and we wish you the best of luck :)", grade.grade));
            }

            return Ok();
        }

        public class GradeRecived
        {
            public string username, grade, data, materie, tipNota, idNota;

            public GradeRecived(string username, string grade, string data, string materie, string tipNota, string idNota)
            {
                this.username = username;
                this.grade = grade;
                this.data = data;
                this.materie = materie;
                this.tipNota = tipNota;
                this.idNota = idNota;
            }
            
        }


        // PUT: api/Grades/<id>
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
        

        // DELETE: api/Grades/<id>
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

        public class PercentageJSON
        {
            public string Examen { get; set; }
            public string Partial { get; set; }
            public string Seminar { get; set; }
            public Dictionary<string, Object> Laborator { get; set; }
            public string Bonus { get; set; }
            public string Materie { get; set; }
        }
    }
}