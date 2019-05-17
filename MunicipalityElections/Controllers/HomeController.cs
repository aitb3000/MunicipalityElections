using MunicipalityElections.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace MunicipalityElections.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
           
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View(); 
        }

        [HttpPost]
        public ActionResult SendMail(Mail newMail)
        {
            if(!ModelState.IsValid)
            {
                var mailModel = new Mail
                {
                    Message = newMail.Message,
                    Name = newMail.Name,
                    Telephone = newMail.Telephone,
                    FromEmail = newMail.FromEmail
                };
                return View("Contact",mailModel);
            }


            SmtpClient smtpClient = new SmtpClient("smtp.mail.com",587);
            smtpClient.EnableSsl = true;
            smtpClient.Credentials = new System.Net.NetworkCredential("dodo_abotbol3000@mail.com", "zaq!2wsx");
            smtpClient.UseDefaultCredentials = false;
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;


            MailMessage mailMessage = new MailMessage();
            mailMessage.From = (new MailAddress(newMail.FromEmail));
            mailMessage.To.Add("dodo_abotbol3000@mail.com");
            mailMessage.Body = newMail.Message + "\n" + newMail.Telephone;
            mailMessage.Subject = "New Contant " + DateTime.Now.ToShortDateString();
            //smtpClient.Send(mailMessage);
            return View("Contact");
        }
    }
}