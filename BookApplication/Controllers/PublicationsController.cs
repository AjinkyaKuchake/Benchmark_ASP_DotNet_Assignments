using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Windows.Forms;
using BookApplication.Models;//Included manually

namespace BookApplication.Controllers
{
    public class PublicationsController : Controller
    {
        // GET: Publications/Index
        //public ActionResult Index()
        //{
        //    BookDBEntities db = new BookDBEntities();
        //    List<Publication> publications = db.Publications.ToList();
        //    return View(publications);
        //}

        public ActionResult Index(string SortColumn = "PublicationName", string IconClass = "fa-sort-asc")
        {
            BookDBEntities db = new BookDBEntities();
            List<Publication> publications = db.Publications.ToList();


            /*For Sorting*/
            ViewBag.SortColumn = SortColumn;
            ViewBag.IconClass = IconClass;

            if (ViewBag.SortColumn == "PublicationID")
            {
                if (ViewBag.IconClass == "fa-sort-asc")
                {
                    publications = publications.OrderBy(temp => temp.PublicationID).ToList();
                }
                else
                {
                    publications = publications.OrderByDescending(temp => temp.PublicationID).ToList();
                }
            }

            if (ViewBag.SortColumn == "PublicationName")
            {
                if (ViewBag.IconClass == "fa-sort-asc")
                {
                    publications = publications.OrderBy(temp => temp.PublicationName).ToList();
                }
                else
                {
                    publications = publications.OrderByDescending(temp => temp.PublicationName).ToList();
                }
            }

            if (ViewBag.SortColumn == "Country")
            {
                if (ViewBag.IconClass == "fa-sort-asc")
                {
                    publications = publications.OrderBy(temp => temp.Country).ToList();
                }
                else
                {
                    publications = publications.OrderByDescending(temp => temp.Country).ToList();
                }
            }

            return View(publications);
        }

        //POST: Publications/Create
        public ActionResult Create()
        {
            return View();
        }

        //Insert
        [HttpPost]
        public ActionResult Create(Publication p)
        {
            BookDBEntities db = new BookDBEntities();
            db.Publications.Add(p);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        //Edit
        public ActionResult Edit(long id)
        {
            BookDBEntities db = new BookDBEntities();
            Publication existingPublication = db.Publications.Where(temp => temp.PublicationID == id).FirstOrDefault();
            return View(existingPublication);
        }

        [HttpPost]
        public ActionResult Edit(Publication p)
        {
            BookDBEntities db = new BookDBEntities();
            Publication existingPublication = db.Publications.Where(temp => temp.PublicationID == p.PublicationID).FirstOrDefault();
            existingPublication.PublicationName = p.PublicationName;
            existingPublication.Country = p.Country;
            
            db.SaveChanges();
            return RedirectToAction("Index", "Publications");
        }

        public ActionResult Details(long id)
        {
            BookDBEntities db = new BookDBEntities();
            Publication p = db.Publications.Where(temp => temp.PublicationID == id).FirstOrDefault();
            return View(p);
        }
        public ActionResult Delete(long id)
        {
            BookDBEntities db = new BookDBEntities();
            Publication existingPublication = db.Publications.Where(temp=>temp.PublicationID==id).FirstOrDefault();
          
            string message = "Do you want to Delete this Record?";
            string title = "Delete Window";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, title, buttons);
            if (result == DialogResult.Yes)
            {
                db.Publications.Remove(existingPublication);
                db.SaveChanges();
                return RedirectToAction("Index","Publications");
;           }
            else
            {
                return RedirectToAction("Index", "Publications");
            }
            
        }
    }
}