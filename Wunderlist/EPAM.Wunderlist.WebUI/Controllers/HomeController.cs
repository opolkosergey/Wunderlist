using System.Web.Mvc;

namespace EPAM.Wunderlist.WebUI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}