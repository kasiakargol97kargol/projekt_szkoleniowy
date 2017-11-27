using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using projekt_szkoleniowy.Models;

namespace projekt_szkoleniowy.Controllers
{
    public class BookEditController : Controller
    {
        DB db = new DB();

        public ActionResult Index()
        {
            /*Check if database has elements*/
            if (db.tBooks.Count() > 0)
            {
                var BookList = (from item in db.tBooks
                                orderby item.Title
                                select item).ToList();
                return View(BookList);
            }
            else
            {
                return View();
            }
        }

        [HttpGet]

        public ActionResult BookEdit(int? id)
        {
            Book toEdit;
            /*Check if book exist*/
            if (id != null)
            {
                toEdit = db.tBooks.Find(id);
                if (toEdit == null)
                {
                    return new HttpNotFoundResult();
                }
            }
            else
            {
                toEdit = new Book();
            }
            return View(toEdit);
        }

        [HttpGet]

        public ActionResult BookDel(int? id)
        {
            Book toDel;
            toDel = db.tBooks.Find(id);
            if (toDel == null)
            {
                return new HttpNotFoundResult();
            }
            return View(toDel);
        }

        [HttpPost]

        public ActionResult BookEdit(Book book)
        {
            if (ModelState.IsValid)
            {
                Book toEdit;
                /*Check if book is new or edited*/
                if (book.Id == 0)
                {
                    /*Search author name and surname through database*/
                    Author aut = db.tAuthors.Where(x => x.Name == book.Author.Name &&
                    x.Surname == book.Author.Surname).FirstOrDefault();

                    /*Check if author exist*/
                    if (aut != null)
                    {
                        book.Author = aut;
                        db.tBooks.Add(book);
                        db.SaveChanges();
                    }
                    else
                    {
                        db.tAuthors.Add(book.Author);
                        db.tBooks.Add(book);
                        db.SaveChanges();
                    }
                }
                /*Book is edited*/
                else
                {
                    toEdit = db.tBooks.Find(book.Id);
                    if (toEdit != null)
                    {
                        toEdit.Title = book.Title;
                        toEdit.ReleaseDate = book.ReleaseDate;
                        toEdit.ISBN = book.ISBN;
                        toEdit.Author = new Author();

                        Author aut = db.tAuthors.Where(x => x.Name == book.Author.Name &&
                            x.Surname == book.Author.Surname).FirstOrDefault();

                        toEdit.Author = aut;
                    }
                }
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(book);
        }

        [HttpPost]

        public ActionResult BookDel(Book book)
        {
            Book toDel;
            toDel = db.tBooks.Find(book.Id);
            if (toDel != null)
            {
                db.tBooks.Remove(toDel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        /*Send list names and surnames for autocomplite*/
        public JsonResult GetAutNamesList(string term)
        {
            var autNameList = db.tAuthors.Where(x => x.Name.Contains(term)).Select(y => y.Name).ToList();

            return Json(autNameList, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetAutSurnamesList(string term)
        {
            var autSurnameList = db.tAuthors.Where(x => x.Surname.Contains(term)).Select(y => y.Surname).ToList();

            return Json(autSurnameList, JsonRequestBehavior.AllowGet);
        }
    }
}