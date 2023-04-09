using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace IMS.CoreBusiness.Models
{
    public class Email
    {
        public static void Send(string to, string subject, string body)
        {
            using var message = new MailMessage();
            message.To.Add(new MailAddress(to));
            message.Subject = subject;
            message.Body = body;
            using var client = new SmtpClient("smtp.gmail.com", 587);
            client.EnableSsl = true;
            client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential("your-email@gmail.com", "your-password");
            client.Send(message);
        }
    }

}
