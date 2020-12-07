using ASP.NET_Developer_Challenge_test.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace ASP.NET_Developer_Challenge_test.Controllers
{
    public class HomeController : Controller
    {
        private MyDbContext myDbContext = new MyDbContext();
        public ActionResult Index()
        {
            MainVM mainVM = new MainVM();
            var services = myDbContext.Services.ToList();
            var innterrests = myDbContext.Interrest.ToList();
            mainVM.Services = services;
            mainVM.Interrests = innterrests;
            return View(mainVM);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public JsonResult SendData(string name, string phone, string email, List<string> services, string plan)
        {
            string servesesToSend = "";
            foreach (var service in services)
            {
                servesesToSend += service + ", \n";
            }
            string mailBody = string.Format("Dear {0} \n You select Services : \n {1} with plan {2} and phone {3}", name, servesesToSend, plan, phone);
            if (sendMail(email, mailBody))
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }

        public static bool sendMail(string Email , string content)
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
                mail.From = new MailAddress("qualifyapi@gmail.com");
                mail.To.Add(Email);
                mail.Subject = "Services Registration";
                mail.Body = content;
                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential("qualifyapi@gmail.com", "Aishame_911");
                SmtpServer.EnableSsl = true;
                SmtpServer.Send(mail);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}