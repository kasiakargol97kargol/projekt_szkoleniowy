using System.Linq;
using System.Web.Mvc;
using projekt_szkoleniowy.Models;

namespace projekt_szkoleniowy.Controllers
{
    public class BookListController : Controller
    {
        public ActionResult Index()
        {
            DB db = new Models.DB();

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
    }
}