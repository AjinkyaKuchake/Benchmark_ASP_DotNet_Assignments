using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookApplication.Models;//Manually Included

namespace BookApplication.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            BookDBEntities db = new BookDBEntities();
            List<Book> books = db.Books.ToList();
            return View(books);
        }
    }
}