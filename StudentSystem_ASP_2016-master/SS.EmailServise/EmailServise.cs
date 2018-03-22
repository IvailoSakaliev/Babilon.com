using DataAcsess.Models;
using SS.GenericServise;
using System;
using System.Net;
using System.Net.Mail;

namespace SS.EmailServise
{
    public class EmailServise : BaseServise<SingIn>
    {
        public SingIn User { get; set; }

        public EmailServise()
            :base()
        {

        }

        public EmailServise(SingIn user)
        {
            this.User = user;
        }

        public void SendEmail()
        {
            var admin = GetByID(1);
            SmtpClient smtpClient = new SmtpClient();
            NetworkCredential basicCredential =
                new NetworkCredential(admin.Email, admin.Password);
            MailMessage message = new MailMessage();
            MailAddress fromAddress = new MailAddress(User.Email);

            smtpClient.Host = "smtp.gmail.com";
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = basicCredential;
            smtpClient.EnableSsl = true;
            smtpClient.Port = 587;

            message.From = fromAddress;
            message.Subject = "Confirm registration";
            message.IsBodyHtml = true;
            message.Body = "Please to confirm your registration in StudentSystem http://studentsystem.azurewebsites.net/SingIN/Confirm/" + User.ID;
            message.To.Add(User.Email);
            smtpClient.Send(message);
        }
    }
}
