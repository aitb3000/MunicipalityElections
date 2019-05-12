using System;
using System.Collections.Generic;
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

        public ActionResult SendMail()
        {
            //SmtpClient smtpClient = new SmtpClient("", 25);

            //smtpClient.Credentials = new System.Net.NetworkCredential("", "");
            //smtpClient.UseDefaultCredentials = true;
            //smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            //smtpClient.EnableSsl = true;
            //MailMessage mail = new MailMessage();

            ////Setting From , To and CC
            //mail.From = new MailAddress("", "");
            //mail.To.Add(new MailAddress(""));
            //mail.CC.Add(new MailAddress(""));

            //smtpClient.Send(mail);

            return View("Contact");
        }
    }
}