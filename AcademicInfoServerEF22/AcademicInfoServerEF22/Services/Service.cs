using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;
using AcademicInfoServerEF22EF22.Models;

namespace AcademicInfoServerEF22.Services
{
    public class Service
    {
        private readonly AcademicInfoContext _context;

        public Service(AcademicInfoContext context)
        {
            _context = context;
        }

        public void SendMailToStudents(List<Student> students, string subject, string messageBody)
        {
            List<String> emails = students.Select(s => s.Email).ToList();

            MailMessage msg = new MailMessage();
            msg.From = new MailAddress("da6447743@gmail.com");

            //Receivers
            foreach (var email in emails)
            {
                msg.To.Add(new MailAddress(email));
            }
            msg.Priority = MailPriority.High;
            msg.Subject = subject;
            msg.Body = messageBody;
            msg.IsBodyHtml = true;

            // Attaching some data
            //msg.Attachments.Add(new Attachment("C:\\Site.lnk"));

            // Connecting to the server and configuring it
            SmtpClient client = new SmtpClient();
            client.Host = "smtp.gmail.com";
            client.Port = 587;
            client.EnableSsl = true;
            client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential("da6447743@gmail.com", "pass1234pass");
            client.DeliveryMethod = SmtpDeliveryMethod.Network;

            client.Send(msg);
        }

        public List<double> GetGradesByYearAndSpecialization(string year, string specialization)
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

            return grades;
        }
    }
}
