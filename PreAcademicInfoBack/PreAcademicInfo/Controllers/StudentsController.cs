using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PreAcademicInfo.Models;
using System.Security.Cryptography;
using System.IO;
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
            _context = context; String fileName0 = "C:\\ASDFASDFK\\Uni\\Proiect Colectiv\\Faculties.txt";
            ReadAndPopulateFaculties(fileName0);
            _context.SaveChanges();
            String fileName1 = "C:\\ASDFASDFK\\Uni\\Proiect Colectiv\\Departments.txt";
            ReadAndPopulateDepartments(fileName1);
            _context.SaveChanges();
            String fileName2 = "C:\\ASDFASDFK\\Uni\\Proiect Colectiv\\Admins.txt";
            ReadAndPopulateAdmins(fileName2);
            _context.SaveChanges();
            String fileName3 = "C:\\ASDFASDFK\\Uni\\Proiect Colectiv\\Specializations.txt";
            ReadAndPopulateSpecializations(fileName3);
            _context.SaveChanges();
            String fileName4 = "C:\\ASDFASDFK\\Uni\\Proiect Colectiv\\Teachers.txt";
            ReadAndPopulateTeachers(fileName4);
            _context.SaveChanges();
            String fileName5 = "C:\\ASDFASDFK\\Uni\\Proiect Colectiv\\Students.txt";
            ReadAndPopulateStudents(fileName5);
            _context.SaveChanges();
            String fileName6 = "C:\\ASDFASDFK\\Uni\\Proiect Colectiv\\Groups.txt";
            ReadAndPopulateGroups(fileName6);
            _context.SaveChanges();
            String fileName7 = "C:\\ASDFASDFK\\Uni\\Proiect Colectiv\\FacultyEnrolls.txt";
            ReadAndPopulateFacultyEnrolls(fileName7);
            _context.SaveChanges();
            String fileName8 = "C:\\ASDFASDFK\\Uni\\Proiect Colectiv\\Disciplines.txt";
            ReadAndPopulateDisciplines(fileName8);
            _context.SaveChanges();
            String fileName9 = "C:\\ASDFASDFK\\Uni\\Proiect Colectiv\\GradesToDiscipline.txt";
            ReadAndPopulateGradesToDiscipline(fileName9);
            _context.SaveChanges();
            String fileName10 = "C:\\ASDFASDFK\\Uni\\Proiect Colectiv\\Grades.txt";
            ReadAndPopulateGrades(fileName10);

            _context.Faculty.ToList();
            _context.Department.ToList();
            _context.Admin.ToList();
            _context.Specializare.ToList();
            _context.Teacher.ToList();
            _context.Student.ToList();
            _context.Group.ToList();
            _context.FacultyEnroll.ToList();
            _context.Discipline.ToList();
            _context.GradesToDiscipline.ToList();
            _context.Grade.ToList();
            List<Faculty> faculties = _context.Faculty.Select(f => f).ToList();
            List<Department> departments = _context.Department.Select(f => f).ToList();
            List<Admin> admins = _context.Admin.Select(f => f).ToList();
            List<Specializare> specializations = _context.Specializare.Select(f => f).ToList();
            List<Teacher> teachers = _context.Teacher.Select(f => f).ToList();
            List<Student> students = _context.Student.Select(f => f).ToList();
            List<Group> groups = _context.Group.Select(f => f).ToList();
            List<FacultyEnroll> facultyEnrolls = _context.FacultyEnroll.Select(f => f).ToList();
            List<Discipline> disciplines = _context.Discipline.Select(f => f).ToList();
            List<GradesToDiscipline> gradesToDisciplines = _context.GradesToDiscipline.Select(f => f).ToList();
            List<Grade> grades = _context.Grade.Select(f => f).ToList();

            _context.SaveChanges();

            //PopulateDatabase();
        }

        string ReadAndPopulateFaculties(string fileName)
        {
            string program = "";
            string line;

            try
            {
                //Pass the file path and file name to the StreamReader constructor
                StreamReader sr = new StreamReader(fileName);

                //Read the first line of text
                line = sr.ReadLine();

                //Continue to read until you reach end of file
                while (line != null)
                {
                    program = program + line;
                    Faculty facultySample = new Faculty();
                    List<String> s;
                    s = line.Split(' ').ToList();
                    facultySample.NumeUniveristate = s[0];
                    facultySample.Nume = s[1];
                    facultySample.Adresa = s[2];
                    _context.Add(facultySample);
                    //List<Department> departments = _context.Department.Select(f => f).ToList();
                    //foreach (Department d in departments)
                    //    if (d.Faculty.Id == facultySample.Id)
                    //        facultySample.Departments.Add(d);

                    //close the file
                    line = sr.ReadLine();
                }
                sr.Close();
                return program;
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
                return "";
            }
            finally
            {
                Console.WriteLine("Executing finally block.");
            }
        }

        string ReadAndPopulateDepartments(string fileName)
        {
            string program = "";
            string line;

            try
            {
                //Pass the file path and file name to the StreamReader constructor
                StreamReader sr = new StreamReader(fileName);

                //Read the first line of text
                line = sr.ReadLine();

                //Continue to read until you reach end of file
                while (line != null)
                {
                    program = program + line;
                    Department departmentSample = new Department();
                    List<String> s;
                    s = line.Split(' ').ToList();
                    departmentSample.Name = s[0];
                    List<Faculty> faculties = _context.Faculty.Select(f => f).ToList();
                    foreach (Faculty f in faculties)
                        if (f.Nume == s[1])
                            departmentSample.Faculty = f;
                    _context.Add(departmentSample);
                    //List<Specializare> specializations = _context.Specializare.Select(f => f).ToList();
                    //foreach (Specializare sp in specializations)
                    //    if (sp.Department.Name == departmentSample.Name)
                    //        departmentSample.Specializares.Add(sp);

                    //close the file
                    line = sr.ReadLine();
                }

                sr.Close();
                return program;
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
                return "";
            }
            finally
            {
                Console.WriteLine("Executing finally block.");
            }
        }

        string ReadAndPopulateAdmins(string fileName)
        {
            string program = "";
            string line;

            try
            {
                //Pass the file path and file name to the StreamReader constructor
                StreamReader sr = new StreamReader(fileName);

                //Read the first line of text
                line = sr.ReadLine();

                //Continue to read until you reach end of file
                while (line != null)
                {
                    program = program + line;
                    Admin adminSample = new Admin();
                    List<String> s;
                    s = line.Split(' ').ToList();

                    byte[] saltNumber = new byte[10];
                    rngCsp.GetBytes(saltNumber);
                    String saltString = System.Text.Encoding.Default.GetString(saltNumber);
                    String password = BCrypt.Net.BCrypt.HashPassword(saltString + s[1]);
                    adminSample.Username = s[0];
                    adminSample.Password = password;
                    adminSample.Salt = saltString;
                    adminSample.Email = s[2];
                    adminSample.Nume = s[3];
                    adminSample.Prenume = s[4];
                    adminSample.NumarTelefon = s[5];
                    adminSample.UserType = UserType.ADMIN;
                    adminSample.Adresa = s[6];
                    _context.Add(adminSample);
                    //List<Specializare> specializations = _context.Specializare.Select(st => st).ToList();
                    //foreach (Specializare sp in specializations)
                    //    if (sp.Admin.Username == adminSample.Username)
                    //        adminSample.Specializares.Add(sp);

                    //close the file
                    line = sr.ReadLine();
                }
                sr.Close();
                return program;
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
                return "";
            }
            finally
            {
                Console.WriteLine("Executing finally block.");
            }
        }

        string ReadAndPopulateSpecializations(string fileName)
        {
            string program = "";
            string line;

            try
            {
                //Pass the file path and file name to the StreamReader constructor
                StreamReader sr = new StreamReader(fileName);

                //Read the first line of text
                line = sr.ReadLine();

                //Continue to read until you reach end of file
                while (line != null)
                {
                    program = program + line;
                    Specializare specializationSample = new Specializare();
                    List<String> s;
                    s = line.Split(' ').ToList();
                    specializationSample.Nume = s[0];
                    List<Department> departments = _context.Department.Select(f => f).ToList();
                    foreach (Department d in departments)
                        if (d.Name == s[1])
                            specializationSample.Department = d;
                    switch (s[2])
                    {
                        case "MASTER":
                            specializationSample.Type = SpecializareType.MASTER;
                            break;
                        case "LICENTA":
                            specializationSample.Type = SpecializareType.LICENTA;
                            break;
                        case "DOCTORAT":
                            specializationSample.Type = SpecializareType.DOCTORAT;
                            break;
                        default:
                            break;
                    }
                    switch (s[3])
                    {
                        case "ROMANA":
                            specializationSample.Limba = Limba.ROMANA;
                            break;
                        case "ENGLEZA":
                            specializationSample.Limba = Limba.ENGLEZA;
                            break;
                        case "MAGHIARA":
                            specializationSample.Limba = Limba.MAGHIARA;
                            break;
                        case "GERMANA":
                            specializationSample.Limba = Limba.GERMANA;
                            break;
                        default:
                            break;
                    }
                    specializationSample.NumarSemestre = int.Parse(s[4]);
                    specializationSample.TaxaPerCredit = double.Parse(s[5]);
                    List<Admin> admins = _context.Admin.Select(f => f).ToList();
                    foreach (Admin a in admins)
                        if (a.Username == s[6])
                            specializationSample.Admin = a;
                    specializationSample.CuFrecventa = bool.Parse(s[7]);
                    _context.Add(specializationSample);
                    //List<Discipline> disciplines = _context.Discipline.Select(f => f).ToList();
                    //foreach (Discipline d in disciplines)
                    //    if (d.Specializare.Id == specializationSample.Id)
                    //        specializationSample.Disciplines.Add(d);

                    //close the file
                    line = sr.ReadLine();
                }

                sr.Close();
                return program;
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
                return "";
            }
            finally
            {
                Console.WriteLine("Executing finally block.");
            }

        }

        string ReadAndPopulateTeachers(string fileName)
        {
            string program = "";
            string line;

            try
            {
                //Pass the file path and file name to the StreamReader constructor
                StreamReader sr = new StreamReader(fileName);

                //Read the first line of text
                line = sr.ReadLine();

                //Continue to read until you reach end of file
                while (line != null)
                {
                    program = program + line;
                    Teacher teacherSample = new Teacher();
                    List<String> s;
                    s = line.Split(' ').ToList();

                    byte[] saltNumber = new byte[10];
                    rngCsp.GetBytes(saltNumber);
                    String saltString = System.Text.Encoding.Default.GetString(saltNumber);
                    String password = BCrypt.Net.BCrypt.HashPassword(saltString + s[1]);
                    teacherSample.Username = s[0];
                    teacherSample.Password = password;
                    teacherSample.Salt = saltString;
                    teacherSample.Email = s[2];
                    teacherSample.Nume = s[3];
                    teacherSample.Prenume = s[4];
                    teacherSample.NumarTelefon = s[5];
                    teacherSample.UserType = UserType.TEACHER;
                    _context.Add(teacherSample);
                    //List<Discipline> disciplines = _context.Discipline.Select(f => f).ToList();
                    //foreach (Discipline d in disciplines)
                    //    if (d.Teacher.Username == teacherSample.Username)
                    //        teacherSample.DisciplinesHolded.Add(d);

                    //close the file
                    line = sr.ReadLine();
                }

                sr.Close();
                return program;
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
                return "";
            }
            finally
            {
                Console.WriteLine("Executing finally block.");
            }
        }

        string ReadAndPopulateStudents(string fileName)
        {
            string program = "";
            string line;

            try
            {
                //Pass the file path and file name to the StreamReader constructor
                StreamReader sr = new StreamReader(fileName);

                //Read the first line of text
                line = sr.ReadLine();

                //Continue to read until you reach end of file
                while (line != null)
                {
                    program = program + line;
                    Student studentSample = new Student();
                    List<String> s;
                    s = line.Split(' ').ToList();

                    byte[] saltNumber = new byte[10];
                    rngCsp.GetBytes(saltNumber);
                    String saltString = System.Text.Encoding.Default.GetString(saltNumber);
                    String password = BCrypt.Net.BCrypt.HashPassword(saltString + s[2]);
                    studentSample.Username = s[0];
                    studentSample.NumarMatricol = int.Parse(s[1]);
                    studentSample.Password = password;
                    studentSample.Salt = saltString;
                    studentSample.Email = s[3];
                    studentSample.Nume = s[4];
                    studentSample.Prenume = s[5];
                    studentSample.NumarTelefon = s[6];
                    studentSample.CNP = s[7];
                    studentSample.InitialaParinte = s[8];
                    studentSample.Active = bool.Parse(s[9]);
                    studentSample.Generatie = s[10];
                    studentSample.An = s[11];
                    studentSample.UserType = UserType.STUDENT;
                    _context.Add(studentSample);
                    //List<FacultyEnroll> faculties = _context.FacultyEnroll.Select(fe => fe).ToList();
                    //foreach (FacultyEnroll f in faculties)
                    //        if (f.Student.Username == studentSample.Username)
                    //            studentSample.FacultiesEnrolled.Add(f);

                    //close the file
                    line = sr.ReadLine();
                }
                sr.Close();
                return program;
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
                return "";
            }
            finally
            {
                Console.WriteLine("Executing finally block.");
            }
        }

        string ReadAndPopulateGroups(string fileName)
        {
            string program = "";
            string line;

            try
            {
                //Pass the file path and file name to the StreamReader constructor
                StreamReader sr = new StreamReader(fileName);

                //Read the first line of text
                line = sr.ReadLine();

                //Continue to read until you reach end of file
                while (line != null)
                {
                    program = program + line;
                    Group groupSample = new Group();
                    List<String> s;
                    s = line.Split(' ').ToList();

                    groupSample.GroupName = s[0];
                    _context.Add(groupSample);
                    //List<FacultyEnroll> faculties = _context.FacultyEnroll.Select(st => st).ToList();
                    //foreach (FacultyEnroll f in faculties)
                    //    if (f.Group.Id == groupSample.Id)
                    //        groupSample.FacultiesEnrolments.Add(f);

                    //close the file
                    line = sr.ReadLine();
                }

                sr.Close();
                return program;
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
                return "";
            }
            finally
            {
                Console.WriteLine("Executing finally block.");
            }
        }

        string ReadAndPopulateFacultyEnrolls(string fileName)
        {
            string program = "";
            string line;

            try
            {
                //Pass the file path and file name to the StreamReader constructor
                StreamReader sr = new StreamReader(fileName);

                //Read the first line of text
                line = sr.ReadLine();

                //Continue to read until you reach end of file
                while (line != null)
                {
                    program = program + line;
                    FacultyEnroll facultyEnrollSample = new FacultyEnroll();
                    List<String> s;
                    s = line.Split(' ').ToList();
                    List<Specializare> specializations = _context.Specializare.Select(f => f).ToList();
                    foreach (Specializare sp in specializations)
                        if (sp.Nume == s[0])
                            facultyEnrollSample.Specializare = sp;
                    List<Group> groups = _context.Group.Select(f => f).ToList();
                    foreach (Group gr in groups)
                        if (gr.GroupName == s[1])
                            facultyEnrollSample.Group = gr;
                    List<Student> students = _context.Student.Select(f => f).ToList();
                    foreach (Student st in students)
                        if (st.Username == s[2])
                            facultyEnrollSample.Student = st;
                    _context.Add(facultyEnrollSample);
                    //close the file
                    line = sr.ReadLine();
                }
                sr.Close();
                return program;
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
                return "";
            }
            finally
            {
                Console.WriteLine("Executing finally block.");
            }
        }

        string ReadAndPopulateDisciplines(string fileName)
        {
            string program = "";
            string line;

            try
            {
                //Pass the file path and file name to the StreamReader constructor
                StreamReader sr = new StreamReader(fileName);

                //Read the first line of text
                line = sr.ReadLine();

                //Continue to read until you reach end of file
                while (line != null)
                {
                    program = program + line;
                    Discipline disciplineSample = new Discipline();
                    List<String> s;
                    s = line.Split(' ').ToList();
                    switch (s[0])
                    {
                        case "OBLIGATORIU":
                            disciplineSample.Type = DisciplineType.OBLIGATORIU;
                            break;
                        case "OPTIONAL":
                            disciplineSample.Type = DisciplineType.OPTIONAL;
                            break;
                        case "FACULTATIV":
                            disciplineSample.Type = DisciplineType.OBLIGATORIU;
                            break;
                        default:
                            break;
                    }
                    List<Specializare> specializations = _context.Specializare.Select(f => f).ToList();
                    foreach (Specializare sp in specializations)
                        if (sp.Nume == s[1])
                            disciplineSample.Specializare = sp;
                    disciplineSample.Cod = s[2];
                    disciplineSample.Nume = s[3];
                    disciplineSample.Credite = int.Parse(s[4]);
                    disciplineSample.An = int.Parse(s[5]);
                    disciplineSample.Semestru = int.Parse(s[6]);
                    List<Teacher> teachers = _context.Teacher.Select(f => f).ToList();
                    foreach (Teacher t in teachers)
                        if (t.Username == s[7])
                            disciplineSample.Teacher = t;
                    _context.Add(disciplineSample);

                    //close the file
                    line = sr.ReadLine();
                }

                sr.Close();
                return program;
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
                return "";
            }
            finally
            {
                Console.WriteLine("Executing finally block.");
            }
        }

        string ReadAndPopulateGradesToDiscipline(string fileName)
        {
            string program = "";
            string line;

            try
            {
                //Pass the file path and file name to the StreamReader constructor
                StreamReader sr = new StreamReader(fileName);

                //Read the first line of text
                line = sr.ReadLine();

                //Continue to read until you reach end of file
                while (line != null)
                {
                    program = program + line;
                    GradesToDiscipline gradeToDisciplineSample = new GradesToDiscipline();
                    List<String> s;
                    s = line.Split(' ').ToList();
                    List<Discipline> disciplines = _context.Discipline.Select(f => f).ToList();
                    foreach (Discipline d in disciplines)
                        if (d.Nume == s[0])
                            gradeToDisciplineSample.Discipline = d;
                    _context.Add(gradeToDisciplineSample);
                    //close the file
                    line = sr.ReadLine();
                }
                sr.Close();
                return program;
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
                return "";
            }
            finally
            {
                Console.WriteLine("Executing finally block.");
            }
        }

        string ReadAndPopulateGrades(string fileName)
        {
            string program = "";
            string line;

            try
            {
                //Pass the file path and file name to the StreamReader constructor
                StreamReader sr = new StreamReader(fileName);

                //Read the first line of text
                line = sr.ReadLine();

                //Continue to read until you reach end of file
                while (line != null)
                {
                    program = program + line;
                    Grade gradeSample = new Grade();
                    List<String> s;
                    s = line.Split(' ').ToList();
                    List<Discipline> disciplines = _context.Discipline.Select(f => f).ToList();
                    foreach (Discipline d in disciplines)
                        if (d.Nume == s[0])
                            gradeSample.Discipline = d;
                    List<Student> students = _context.Student.Select(f => f).ToList();
                    foreach (Student st in students)
                        if (st.Username == s[1])
                            gradeSample.Student = st;
                    gradeSample.GradeValue = double.Parse(s[2]);
                    switch (s[3])
                    {
                        case "LAB":
                            gradeSample.Type = GradeType.LAB;
                            break;
                        case "SEMINAR":
                            gradeSample.Type = GradeType.SEMINAR;
                            break;
                        case "EXAMEN":
                            gradeSample.Type = GradeType.EXAMEN;
                            break;
                        case "PARTIAL":
                            gradeSample.Type = GradeType.PARTIAL;
                            break;
                        case "BONUS":
                            gradeSample.Type = GradeType.BONUS;
                            break;
                        case "FINAL":
                            gradeSample.Type = GradeType.FINAL;
                            break;
                        default:
                            break;
                    }
                    gradeSample.ProcentInnerType = double.Parse(s[4]);
                    gradeSample.ProcentOuter = double.Parse(s[5]);
                    gradeSample.DataNotei = s[6];
                    _context.Add(gradeSample);
                    //List<GradesToDiscipline> grades = _context.GradeToDiscipline.Select(st => st).ToList();
                    //foreach (Student st in students)
                    //    if (st.Username == gradeSample.Student.Username)
                    //    foreach (GradesToDiscipline gr in grades)
                    //                st.Grades.Add(gr);

                    //close the file
                    line = sr.ReadLine();
                }

                //GradesToDiscipline g2s = new GradesToDiscipline();
                //g2s.Id = incIdGrades;
                //incIdGrades++;
                //List<Student> studentList = _context.Student.Select(st => st).ToList();
                //List<Grade> gradeList = _context.Grade.Select(st => st).ToList();
                //List<GradesToDiscipline> gradeToDisciplineList = _context.GradeToDiscipline.Select(st => st).ToList();

                sr.Close();
                return program;
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
                return "";
            }
            finally
            {
                Console.WriteLine("Executing finally block.");
            }
        }


        // GET: api/Students
        [HttpGet]
        public IEnumerable<Student> GetStudent()
        {
            //PopulateDatabase();
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