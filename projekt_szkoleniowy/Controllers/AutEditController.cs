using System.Linq;
using System.Web.Mvc;
using projekt_szkoleniowy.Models;

namespace projekt_szkoleniowy.Controllers
{
    public class AutEditController : Controller
    {
        DB db = new DB();

        public ActionResult Index()
        {
            /*Check if database has elements*/
            if (db.tAuthors.Count() > 0)
            {
                var AutList = (from item in db.tAuthors
                               orderby item.Surname
                               select item).ToList();
                return View(AutList);
            }
            else
            {
                return View();
            }
        }

        [HttpGet]

        public ActionResult AutEdit(int? id)
        {
            Author toEdit;
            /*Check if author exist*/
            if (id != null)
            {
                toEdit = db.tAuthors.Find(id);
                if (toEdit == null)
                {
                    return new HttpNotFoundResult();
                }
            }
            else
            {
                toEdit = new Author();
            }
            return View(toEdit);
        }

        [HttpGet]

        public ActionResult AutDel(int id)
        {
            Author toDel;
            toDel = db.tAuthors.Find(id);
            if (toDel == null)
            {
                return new HttpNotFoundResult();
            }
            return View(toDel);
        }

        [HttpPost]

        public ActionResult AutEdit(Author author)
        {
            if (ModelState.IsValid)
            {
                Author toEdit;
                /*Check if author is new or edited*/
                if (author.Id == 0)
                {
                    toEdit = new Author();
                    db.tAuthors.Add(author);
                    db.SaveChanges();
                }
                else
                {
                    toEdit = db.tAuthors.Find(author.Id);
                    if (toEdit != null)
                    {
                        toEdit.Name = author.Name;
                        toEdit.Surname = author.Surname;
                    }
                }
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(author);
        }

        [HttpPost]

        public ActionResult AutDel(Author author)
        {
            Author toDel;
            toDel = db.tAuthors.Find(author.Id);
            if (toDel != null)
            {
                db.tAuthors.Remove(toDel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}