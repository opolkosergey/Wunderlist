using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EPAM.Wunderlist.Model;
using EPAM.Wunderlist.Services.TodoListsService;
using EPAM.Wunderlist.WebUI.Models;
using Microsoft.AspNet.Identity;
using static EPAM.Wunderlist.WebUI.Mapper.HelperConvert;

namespace EPAM.Wunderlist.WebUI.Controllers.WebAPI
{
    public class ListController : ApiController
    {
        private readonly ITodoListsService _listService;

        public ListController(ITodoListsService listService)
        {
            if (listService == null)
                throw new ArgumentNullException(nameof(listService));

            _listService = listService;
        }

        // Получение всех листов
        [HttpGet]
        public IEnumerable<TodoListViewModel> GetAllLists(int userId)
        {
            var lists = _listService.GetAllTodoLists(userId);
            return EntityConvert<TodoListModel, TodoListViewModel>(lists);
        }

        // Создание нового листа для задач
        [HttpPost]
        public HttpResponseMessage CreateList([FromBody]TodoListViewModel list)
        {
            try
            {
                var newList = EntityConvert<TodoListViewModel, TodoListModel>(list);
                _listService.Add(newList);
                return Request.CreateResponse(HttpStatusCode.Created, newList);
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
        }

        // Обновление листа по id
        [HttpPost]
        public HttpResponseMessage UpdateList(int id, [FromBody]TodoListModel list)
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
        }

        // Удаление листа по id
        [HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
        }

        private int GetUserId()
        {
            return User.Identity.GetUserId<int>();
        }
    }
}
