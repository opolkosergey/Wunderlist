using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EPAM.Wunderlist.Model;
using EPAM.Wunderlist.Services.TodoItemsService;
using EPAM.Wunderlist.WebUI.Models;
using static EPAM.Wunderlist.WebUI.Mapper.HelperConvert;

namespace EPAM.Wunderlist.WebUI.Controllers.WebAPI
{
    public class ItemController : ApiController
    {
        private readonly ITodoItemsService _itemService;

        public ItemController(ITodoItemsService itemService)
        {
            if (itemService == null)
                throw new ArgumentNullException(nameof(itemService));

            _itemService = itemService;
        }

        // Получить все item по id листа
        [HttpGet]
        public IEnumerable<TodoItemViewModel> GetAllItems(int id)
        {
            var items = _itemService.GetAllItems(id);
            return EntityConvert<TodoItemModel, TodoItemViewModel>(items);
        }

        // Создание item
        [HttpPost]
        public HttpResponseMessage CreateItem([FromBody]TodoItemViewModel item)
        {
            try
            {
                var newItem = EntityConvert<TodoItemViewModel, TodoItemModel>(item);
                _itemService.Add(newItem);
                return Request.CreateResponse(HttpStatusCode.Created, newItem);
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
        }

        // Обновление item по id
        [HttpPost]
        public HttpResponseMessage UpdateItem(int id, [FromBody]TodoItemViewModel item)
        {
            try
            {
                var itemToUpdate = EntityConvert<TodoItemViewModel, TodoItemModel>(item);
                _itemService.Update(itemToUpdate);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
        }

        // Удаление item по id
        [HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                _itemService.Remove(id);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
        }
    }
}
