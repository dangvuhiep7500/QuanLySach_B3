using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuanLySach_B3.Models;

namespace QuanLySach_B3.Controllers
{
    public class BookController : Controller
    {
        // GET: Book
        BookManagerEntities2 db = new BookManagerEntities2();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ListBook()
        {
            List<Book> ds = db.Books.ToList();
            return View(ds);
        }
        [Authorize]
        public ActionResult Buy(int id)
        {
            Book book = db.Books.SingleOrDefault(p => p.ID == id);
                if(book==null)
            {
                return HttpNotFound();
            }
            return View(book);
        }
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]

        public ActionResult Create(Book book, FormCollection collection)
        {
            if (ModelState.IsValid)
            {
                db.Books.Add(book);
                db.SaveChanges();
                return RedirectToAction("ListBook");
            }

            return this.Create();
        }
        [Authorize]
        public ActionResult Edit(int id)
        {
            var b = db.Books.First(m => m.ID == id);
            return View(b);
        }
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            var b = db.Books.First(m => m.ID == id);
            if (b != null)
            {
                UpdateModel(b);
                db.SaveChanges();
                return RedirectToAction("ListBook");
            }
            return this.Edit(id);
        }
        [Authorize]
        public ActionResult Delete(int id)
        {
            var b = db.Books.First(m => m.ID == id);
            return View(b);
        }
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            var b = db.Books.Where(x => x.ID == id).First();
            db.Books.Remove(b);
            db.SaveChanges();
            return RedirectToAction("ListBook");
        }
        [Authorize]
        public ActionResult Details(int Id)
        {
            Book book = db.Books.First(x => x.ID == Id);
            return View(book);
        }

    }
}