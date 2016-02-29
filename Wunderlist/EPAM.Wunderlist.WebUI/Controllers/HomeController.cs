using System.Web.Mvc;

namespace EPAM.Wunderlist.WebUI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
<<<<<<< HEAD
=======
            ViewBag.RedirectUrl = "/webapp";
>>>>>>> refs/remotes/origin/master
            return View();
        }
    }
}