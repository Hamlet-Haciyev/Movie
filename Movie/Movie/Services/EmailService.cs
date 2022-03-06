using MailKit.Security;
using MimeKit;
using MailKit.Net.Smtp;
using MimeKit.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Movie.Services
{
    public class EmailService
    {
        //public void Send(string to, string subject, string html)
        //{
        //    var email = new MimeMessage();
        //    email.From.Add(MailboxAddress.Parse("shopwisesite@gmail.com"));
        //    email.To.Add(MailboxAddress.Parse(to));
        //    email.Subject = subject;
        //    email.Body = new TextPart(TextFormat.Html) { Text = html };

        //    var smtp = new SmtpClient();
        //    smtp.Connect("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
        //    smtp.Authenticate("shopwisesite@gmail.com", "shopwise!@123");
        //    smtp.Send(email);
        //    smtp.Disconnect(true);
        //}
    }
}
