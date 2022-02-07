using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Windows.Forms;//Manually Included
using BookApplication.Models;//included Manually

namespace BookApplication.Controllers
{
    public class BooksController : Controller
    {
        // GET: Books/Index
        public ActionResult Index(string SortColumn = "BookName", string IconClass = "fa-sort-asc",int PageNo = 1)
        {
            BookDBEntities db = new BookDBEntities();
            List<Book> books = db.Books.ToList();


            /*For Sorting*/
            ViewBag.SortColumn = SortColumn;
            ViewBag.IconClass = IconClass;

            /*Book ID*/
            if (ViewBag.SortColumn == "BookID")
            {
                if (ViewBag.IconClass == "fa-sort-asc")
                {
                    books = books.OrderBy(temp => temp.BookID).ToList();
                }
                else
                {
                    books = books.OrderByDescending(temp => temp.BookID).ToList();
                }
            }

            /*Book Name*/
            if (ViewBag.SortColumn == "BookName")
            {
                if (ViewBag.IconClass == "fa-sort-asc")
                {
                    books = books.OrderBy(temp => temp.BookName).ToList();
                }
                else
                {
                    books = books.OrderByDescending(temp => temp.BookName).ToList();
                }
            }

            /*Price*/
            if (ViewBag.SortColumn == "Price")
            {
                if (ViewBag.IconClass == "fa-sort-asc")
                {
                    books = books.OrderBy(temp => temp.Price).ToList();
                }
                else
                {
                    books = books.OrderByDescending(temp => temp.Price).ToList();
                }
            }

            /*Author*/
            if (ViewBag.SortColumn == "Author")
            {
                if (ViewBag.IconClass == "fa-sort-asc")
                {
                    books = books.OrderBy(temp => temp.Author).ToList();
                }
                else
                {
                    books = books.OrderByDescending(temp => temp.Author).ToList();
                }
            }

            /*Genre*/
            if (ViewBag.SortColumn == "Genre")
            {
                if (ViewBag.IconClass == "fa-sort-asc")
                {
                    books = books.OrderBy(temp => temp.Genre).ToList();
                }
                else
                {
                    books = books.OrderByDescending(temp => temp.Genre).ToList();
                }
            }

            /*Availability*/
            if (ViewBag.SortColumn == "AvailabilityStatus")
            {
                if (ViewBag.IconClass == "fa-sort-asc")
                {
                    books = books.OrderBy(temp => temp.AvailabilityStatus).ToList();
                }
                else
                {
                    books = books.OrderByDescending(temp => temp.AvailabilityStatus).ToList();
                }
            }

            /*Publication ID*/
            if (ViewBag.SortColumn == "PublicationID")
            {
                if (ViewBag.IconClass == "fa-sort-asc")
                {
                    books = books.OrderBy(temp => temp.Publication.PublicationName).ToList();
                }
                else
                {
                    books = books.OrderByDescending(temp => temp.Publication.PublicationName).ToList();
                }
            }

            /*Pagination*/
            int NoOfRecordsPerPage = 5;
            int NoOfPages = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(books.Count)/Convert.ToDouble(NoOfRecordsPerPage)));
            int NoOfRecordsToSkip = (PageNo - 1) * NoOfRecordsPerPage;
            ViewBag.PageNo = PageNo;
            ViewBag.NoOfPages = NoOfPages;
            books = books.Skip(NoOfRecordsToSkip).Take(NoOfRecordsPerPage).ToList();

            return View(books);
        }

        //POST: Books/Create
        public ActionResult Create()
        {
            BookDBEntities db = new BookDBEntities();
            ViewBag.publications = db.Publications.ToList();
            return View();
        }

        //Insert
        [HttpPost]
        public ActionResult Create(Book b)
        {
            BookDBEntities db = new BookDBEntities();

            if (Request.Files.Count >= 1)
            {
                var file = Request.Files[0];
                var imgBytes = new Byte[file.ContentLength - 1];
                file.InputStream.Read(imgBytes, 0, imgBytes.Length);
                var base64String = Convert.ToBase64String(imgBytes,0,imgBytes.Length);
                b.photo = base64String;
            }

            db.Books.Add(b);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        //Edit
        public ActionResult Edit(long id)
        {
            BookDBEntities db = new BookDBEntities();
            Book existingBook = db.Books.Where(temp => temp.BookID == id).FirstOrDefault();

            ViewBag.publications = db.Publications.ToList();
            return View(existingBook);
        }

        [HttpPost]
        public ActionResult Edit(Book b)
        {
            BookDBEntities db = new BookDBEntities();
            Book existingBook = db.Books.Where(temp => temp.BookID == b.BookID).FirstOrDefault();
            existingBook.BookName = b.BookName;
            existingBook.Price= b.Price;
            existingBook.Author = b.Author;
            existingBook.Genre = b.Genre;
            existingBook.AvailabilityStatus = b.AvailabilityStatus;
            existingBook.PublicationID = b.PublicationID;
            if (Request.Files.Count >= 1)
            {
                var file = Request.Files[0];
                var imgBytes = new Byte[file.ContentLength - 1];
                file.InputStream.Read(imgBytes, 0, imgBytes.Length);
                var base64String = Convert.ToBase64String(imgBytes, 0, imgBytes.Length);
                b.photo = base64String;
            }
            existingBook.photo = b.photo;
            db.SaveChanges();
            return RedirectToAction("Index", "Books");
        }

        public ActionResult Details(long id)
        {
            BookDBEntities db = new BookDBEntities();
            Book b = db.Books.Where(temp => temp.BookID == id).FirstOrDefault();
            return View(b);
        }
        public ActionResult Delete(long id)
        {
            BookDBEntities db = new BookDBEntities();
            Book existingBook = db.Books.Where(temp => temp.BookID == id).FirstOrDefault();

            string message = "Do you want to Delete this Record?";
            string title = "Delete Window";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, title, buttons);
            if (result == DialogResult.Yes)
            {
                db.Books.Remove(existingBook);
                db.SaveChanges();
                return RedirectToAction("Index", "Books");
            }
            else
            {
                return RedirectToAction("Index", "Books");
            }

        }
    }
}