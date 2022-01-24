using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;  //Contains predefined classes to work with MVC

namespace MyFirstApp.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Products()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }


        //View with different name
        public ActionResult AboutUs()
        {
            return View("AboutOurCompany");
        }

        //Action Result ContentResult
        public ActionResult GetEmpName(int EmpId)
        {
            //Array of Annonymous type
            var employees = new[] {
            new{ EmpId=1,EmpName="Ajinkya", Salary = 100000},
            new{ EmpId=2,EmpName="Ajju", Salary = 200000},
            new{ EmpId=3,EmpName="Guru", Salary = 300000}
            };

            string MatchingEmpName = null;
            foreach (var item in employees)
            {
                if (EmpId == item.EmpId)
                {
                    MatchingEmpName = item.EmpName;
                }
            }
            //Method 1 Lengthy statement
            //return new ContentResult() { Content = MatchingEmpName, ContentType = "text/plain" };

            //Method 2
            return Content(MatchingEmpName, "text/plain");

        }

        //ActionResult FileResult
        public ActionResult GetPaySlip(int EmpId)
        {
            string fileName = "~/PaySlip" + EmpId + ".pdf";
            return File(fileName, "application/pdf");
        }

        //ActionResult RedirectResult
        public ActionResult SuperHeroPage(string Hero)
        {
            string googleURL = null;
            var Heroes = new[] { new { Hero = "Batman" }, new { Hero = "Superman" }, new { Hero = "Aquaman" } };
            foreach (var item in Heroes)
            {
                if (Hero == item.Hero)
                {
                    googleURL = "https://www.dccomics.com/characters/" + Hero;
                }
            }

            if (googleURL == null)
            {
                return Content("Invalid Super Hero Name");
            }

            else
            {
                return Redirect(googleURL);
            }
        }

        public ActionResult StudentDetails()
        {
            ViewBag.StudentId = 101;
            ViewBag.StudentName = "Ajinkya";
            ViewBag.Marks = 98;
            ViewBag.NoOfSemesters = 6;
            ViewBag.Subjects = new List<string>() { "Maths","Physics","Chemistry"};

            return View();
        }

        //Request Object Example
        public ActionResult RequestExample()
        {
            ViewBag.URL = Request.Url;//Request is Pre-defined object which is directly available in the controller
            ViewBag.Path = Request.Path;
            ViewBag.PhysicalPath = Request.PhysicalPath;
            ViewBag.PhysicalRequestPath = Request.PhysicalApplicationPath;
            ViewBag.BrowserType = Request.Browser.Type;
            ViewBag.QueryString = Request.QueryString["n"];
            ViewBag.Headers = Request.Headers["Accept"];
            ViewBag.HttpMethod = Request.HttpMethod;
            return View();
        }

        public ActionResult ResponseExample()
        {
            //Response.Write("Content") will be printed on top of the Web Page
            Response.Write("Hello Guys...This Website is created by Ajinkya");

            //Normally the Response.ContentType is "text/html", you can also change it
            //Response.ContentType = "text/plain";//Manually changing the ContentType
            ViewBag.ContentType = Response.ContentType;

            //There are multiple headers available oneof them is used below
            Response.Headers["Server"] = "Ajinkya's Server";
            ViewBag.Headers = Response.Headers["Server"];

            //Default StatusCode for any WebPage is 200, but we can also set the StatusCode manually
            Response.StatusCode = 500;//StstusCode set manually
            ViewBag.StatusCode = Response.StatusCode;
            
            return View();
        }
    }
}