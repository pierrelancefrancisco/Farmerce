using Farmerce.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

using System.Net;
using System.Net.Mail;

namespace Farmerce.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Contact()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Contact(Contact record)
        {
            MailMessage mail = new MailMessage()
            {
                From = new MailAddress("mvcapplicationtestrun@gmail.com", "The Administrator")
            };
            mail.To.Add(new MailAddress(record.Email));

            mail.Subject = "Inquiry from " + record.Sender + " (" + record.Subject + ")";
            string message = "Hello, " + record.Sender + "<br/><br/>" + "We " +
                "have received your inquiry. Here are the details: <br/><br/>" +
                "Message: " + record.Message + "<br/><br/>" + "Please wait for our reply. Thank you.";
            mail.Body = message;
            mail.IsBodyHtml = true;

            using SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587)
            {
                Credentials = new NetworkCredential("mvcapplicationtestrun@gmail.com", "4D302EB5AC0A121C4F570594EE0E43001B959AAD5F273CE16AF694A1A05B2B56"),
                EnableSsl = true
            };
            smtp.Send(mail);
            ViewBag.Message = "Inquiry sent.";
            return View();
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
