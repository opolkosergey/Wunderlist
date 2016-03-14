using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EPAM.Wunderlist.Model;
using EPAM.Wunderlist.Services.TodoListsService;
using EPAM.Wunderlist.WebUI.Models;
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
        
        [HttpGet]
        public IEnumerable<TodoListViewModel> GetAllLists(int id)
        {
            var lists = _listService.GetAllTodoLists(id);
            return EntityConvert<TodoListModel, TodoListViewModel>(lists);
        }
        
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
        
        [HttpPut]
        public HttpResponseMessage UpdateList(int id, TodoListViewModel newList)
        {
            try
            {
                var list = _listService.GetById(id);
                list.Name = newList.Name;
                _listService.Update(list);
                return Request.CreateResponse(HttpStatusCode.OK, newList);
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
        }
        
        [HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                _listService.Remove(id);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
        }
    }
}
