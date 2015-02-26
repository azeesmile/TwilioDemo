using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Twilio;
using TwilioDemo.Models;

namespace TwilioDemo.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SendSms(Number formData)
        {
            string AccountSid = "ACccebbd35cfd5bc4688c480be7df0284c";
            string AuthToken = "530877eb5d98a38ce1c001285c35f59b";
            var twilio = new TwilioRestClient(AccountSid, AuthToken);

            var result = twilio.SendMessage("+13393373112", formData.PhoneNumber, string.Format("Test Text Message"));
            if (string.IsNullOrEmpty(result.RestException.Message))
            {
                TempData["message"] = result.RestException.Message;
            }
            return RedirectToAction("Index");
        }

    }
}
