using System.Web.Mvc;
using projekt_szkoleniowy.Models;

namespace projekt_szkoleniowy.Controllers
{
    public class HomeController : Controller
    {
        DB db = new DB();

        public ActionResult Index()
        {
            return View();
        }
    }
}