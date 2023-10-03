using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.Net.Mail;
using smtp.Models;

namespace smtp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SendMail()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SendMail(Email model)
        {

                String from, pass, messageBody;
                from = "bhavanimula07@gmail.com";
                pass = "manx bvoq mafp vtig";
                MailMessage em = new MailMessage();
                em.To.Add(model.To);
                em.From = new MailAddress(from);
                em.Subject = model.Subject;
                em.Body = model.Body;
                SmtpClient smtp = new SmtpClient("smtp.gmail.com");
                smtp.EnableSsl = true;
                smtp.Port = 587;
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Credentials = new NetworkCredential(from,pass);
                smtp.Send(em);
                ViewBag.Message = "Email sent";

            try
            {
                smtp.Send(em);
                ViewBag.Message = "Email sent";
            }
            catch (Exception ex)
            {
                ViewBag.Message = "error while sending";
            }
            return View();



        }
    }
}