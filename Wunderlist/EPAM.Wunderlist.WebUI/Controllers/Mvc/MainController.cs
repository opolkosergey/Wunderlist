using System.Web.Mvc;

namespace EPAM.Wunderlist.WebUI.Controllers.Mvc
{
    [Authorize]
    public class MainController : Controller
    {
        public ActionResult Inbox()
        {
            return View();
        }
    }
}