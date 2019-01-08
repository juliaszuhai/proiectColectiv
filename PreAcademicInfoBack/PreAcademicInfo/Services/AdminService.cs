using PreAcademicInfo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace PreAcademicInfo.Services
{
    public class AdminService
    {
        StudentContext studentContext;

        public AdminService(StudentContext contextStudent)
        {
            this.studentContext = contextStudent;
        }

        public List<Teacher> getTeachers()
        {

            return studentContext.Teacher.ToList();
        }

        public void SendMailToStudents(List<Student> students, string subject, string messageBody)
        {
            List<String> emails =  students.Select(s => s.Email).ToList();
            string adminEmail = studentContext.Admin.Select(a => a.Email).FirstOrDefault();
            string adminPassword = studentContext.Admin.Select(a => a.Password).FirstOrDefault();
            MailMessage msg = new MailMessage();
            msg.From = new MailAddress(adminEmail);

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
            client.Credentials = new NetworkCredential(adminEmail, adminPassword);
            client.DeliveryMethod = SmtpDeliveryMethod.Network;

            client.Send(msg);
        }
    }
}
