using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using System.Web.Mvc;
using EPAM.Wunderlist.Services.Infrastructure.ServiceObjects;
using EPAM.Wunderlist.Services.TodoListsService;
using EPAM.Wunderlist.Services.UserService;

namespace EPAM.Wunderlist.WebUI.Controllers
{
    public class ListController : ApiController
    {
        private readonly ITodoListsService _listsService;
        private readonly IUserService _userService;

        public ListController(ITodoListsService listsService, IUserService userService)
        {
            _listsService = listsService;
            _userService = userService;
        }
        // GET: api/List
        public JsonResult<ArrayList> Get(int id,int page, bool isNeededPagesCount)
        {
            var list = new List<TodoItemServiceObject>
            {
                new TodoItemServiceObject() {ID = 0, TodoTask = "qwerty"},
                new TodoItemServiceObject() {ID = 1, TodoTask = "asdfgh"},
                new TodoItemServiceObject() {ID = 2, TodoTask = "zxcvbnm"},
                new TodoItemServiceObject() {ID = 3, TodoTask = "ghjkljh"},
                new TodoItemServiceObject() {ID = 4, TodoTask = "yrhytjh"},
                new TodoItemServiceObject() {ID = 5, TodoTask = "b kcmbktomb"},
                new TodoItemServiceObject() {ID = 6, TodoTask = "dog egue0 uge"},
                new TodoItemServiceObject() {ID = 7, TodoTask = "reg ege e"}
            };
            var res = list.Skip((page-1) * 4).Take(4).ToList();
            var arrlist = new ArrayList();
            if (isNeededPagesCount)
            {
                if (list.Count % 4 == 0)
                    arrlist.Add(list.Count / 4);
                else arrlist.Add(list.Count / 4 + 1);
            }
            arrlist.AddRange(res);
            return Json(arrlist);
        }

        // GET: api/List/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/List
        public HttpResponseMessage Post([FromBody]TodoListServiceObject data)
        {
            data.UserModelID = _userService.GetUserByName(User.Identity.Name).Id;
            data.ID = _listsService.Add(data);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        // PUT: api/List/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/List/5
        public void Delete(int id)
        {
        }
    }
}
