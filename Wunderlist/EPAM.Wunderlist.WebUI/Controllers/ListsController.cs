using System;
using System.Linq;
using System.Web.Mvc;
using EPAM.Wunderlist.Services.TodoItemsService;
using EPAM.Wunderlist.Services.TodoListsService;
using Microsoft.AspNet.Identity;

namespace EPAM.Wunderlist.WebUI.Controllers
{
    [Authorize]
    public class ListsController : Controller
    {
        private readonly ITodoItemsService _itemService;
        private readonly ITodoListsService _listService;

        public ListsController(ITodoItemsService itemService, ITodoListsService listService)
        {
            if (itemService == null)
                throw new ArgumentNullException(nameof(itemService));

            if(listService == null)
                throw new ArgumentNullException(nameof(listService));

            _itemService = itemService;
            _listService = listService;
        }

        public ActionResult Inbox()
        {
            var lists = _listService.GetAllTodoLists(User.Identity.GetUserId<int>());
            var listIndoxId = lists.First(p => p.Name == "Inbox").ID;
            var inboxItems = _itemService.GetAllItems(listIndoxId);

            ViewBag.Lists = lists;
            ViewBag.InboxItems = inboxItems;

            return View();
        }
    }
}