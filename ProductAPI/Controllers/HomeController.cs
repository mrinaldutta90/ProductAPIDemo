
using System.Web.Mvc;

namespace ProductAPI.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            ViewBag.Title = "Products Web API";
            return View();
        }
    }
}