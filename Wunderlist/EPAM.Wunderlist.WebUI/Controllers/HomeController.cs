using System.Web.Mvc;

namespace EPAM.Wunderlist.WebUI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.RedirectUrl = "/webapp";
            return View();
        }
    }
}