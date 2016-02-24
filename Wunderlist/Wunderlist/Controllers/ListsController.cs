using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Wunderlist.Controllers
{
    public class ListsController : Controller
    {
        // GET: Lists
        public ActionResult Inbox()
        {
            return View();
        }
    }
}