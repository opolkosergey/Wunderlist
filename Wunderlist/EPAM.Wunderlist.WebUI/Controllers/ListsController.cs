using System.Web.Mvc;

namespace EPAM.Wunderlist.WebUI.Controllers
{
    public class ListsController : Controller
    {
        public ActionResult Inbox()
        {
            return View();
        }
    }
}