using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
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
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
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
