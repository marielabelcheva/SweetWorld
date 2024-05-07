using SweetWorld.Core.Contracts;
using SweetWorld.Core.Models.HomeViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace SweetWorld.Core.Services
{
    public class HomeService : IHomeService
    {
        public void ContactUs(ContactUsViewModel model)
        {
            MailMessage mailMessage = new MailMessage(model.From, "meribelcheva@gmail.com");
            mailMessage.Subject = "Sweet world";
            mailMessage.Body = $"Name: {model.SenderName}\nEmail: {model.From}\nMessage: {model.Body}\n";
            mailMessage.IsBodyHtml = false;

            SmtpClient smtpClient = new SmtpClient();
            smtpClient.Host = "smtp.gmail.com";
            smtpClient.Port = 587;
            smtpClient.EnableSsl = true;
            smtpClient.Credentials = new NetworkCredential("meribelcheva@gmail.com", "qpqt nljv iqmg egru");
            smtpClient.Send(mailMessage);
        }
    }
}
