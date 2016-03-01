using System.Web.Mvc;
using EPAM.Wunderlist.Services.TodoListsService;

namespace EPAM.Wunderlist.WebUI.Controllers
{
    public class ListsController : Controller
    {
        private ITodoListsService _listsService;
        public ActionResult Inbox()
        {
            return View();
        }
    }
}