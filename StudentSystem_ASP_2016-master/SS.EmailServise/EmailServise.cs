using DataAcsess.Models;
using SS.GenericServise;
using SS.SingInServise;
using System;
using System.Net;
using System.Net.Mail;

namespace SS.EmailServise
{
    public class EmailServise : BaseServise<SingIn>
    {
        public SingIn User { get; set; }
        private SingInServise.SingInServise singIn = new SingInServise.SingInServise();

        public EmailServise()
            :base()
        {

        }

        public EmailServise(SingIn user)
        {
            this.User = user;
        }

        public void SendConfirmEmail()
        {
            var admin = GetDecriptedInformationForAdmin();
            string userEmail = singIn.DencryptData(User.Email);

            SmtpClient smtpClient = new SmtpClient();
            NetworkCredential basicCredential =
                new NetworkCredential(admin.Email, admin.Password);
            MailMessage message = new MailMessage();
            MailAddress fromAddress = new MailAddress(userEmail);

            smtpClient.Host = "smtp.gmail.com";
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = basicCredential;
            smtpClient.EnableSsl = true;
            smtpClient.Port = 587;

            message.From = fromAddress;
            message.Subject = "Confirm registration";
            message.IsBodyHtml = true;
            message.Body = "Please to confirm your registration in StudentSystem http://studentsystem.azurewebsites.net/SingIN/Confirm/" + User.ID;
            message.To.Add(userEmail);
            smtpClient.Send(message);
        }

        private SingIn GetDecriptedInformationForAdmin()
        {
            var admin = GetByID(1);
            SingIn result = new SingIn();
            result.Email = singIn.DencryptData(admin.Email);
            result.Password = singIn.DencryptData(admin.Password);
            return result;
        }
    }
}
