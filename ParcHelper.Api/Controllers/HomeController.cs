using System.Web.Mvc;

namespace ParkHelper.Api.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            // ReSharper disable once Mvc.ViewNotResolved
            return View();
        }
    }
}
