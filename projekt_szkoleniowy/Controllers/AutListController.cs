using System.Linq;
using System.Web.Mvc;
using projekt_szkoleniowy.Models;

namespace projekt_szkoleniowy.Controllers
{
    public class AutListController : Controller
    {
        public ActionResult Index()
        {
            DB db = new DB();
            /*Check if database has elements*/
            if (db.tAuthors.Count() > 0)
            {
                var AutList = (from item in db.tAuthors
                               orderby item.Name
                               select item).ToList();
                return View(AutList);
            }
            else
            {
                return View();
            }
        }
    }
}