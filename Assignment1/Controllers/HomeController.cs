using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Assignment1.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index(string data)
        {
            string fileName = null;
            if (data == "Sample")
            {
                fileName = "~/" + data + ".pdf";
                return File(fileName, "application/pdf");

            }

            else if (data == "gotoabout")
            {
                return RedirectToAction("About");
            }

            else if (data == "login")
            {
                return View("LoginView");
            }

            else
            {
                return Content("You entered:  "+data);
            }

        }

        public ActionResult About()
        {
            return Content("About Content here");
        }
    }
}