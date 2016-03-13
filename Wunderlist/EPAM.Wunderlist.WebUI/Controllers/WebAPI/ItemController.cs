using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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

        [HttpGet]
        public ArrayList GetAllItems(int id, string page, int pageSize = 4, bool isneedPageCount = false)
        {
            //var items = _itemService.GetAllItems(id);
            int pages = (int)Math.Ceiling((double)_itemService.CountOfUncompleted(id) / pageSize); ;
            var items = _itemService.GetPage(id, page == "maxpage" ? pages : int.Parse(page), pageSize);
            var entities = EntityConvert<TodoItemModel, TodoItemViewModel>(items);
            var list = new ArrayList();
            list.AddRange(entities.ToList());
            var completedItems = _itemService.GetAllItems(id).Where(i => i.Status == TodoStatus.Сompleted);
            list.AddRange(EntityConvert<TodoItemModel, TodoItemViewModel>(completedItems).ToList());
            //list.AddRange(_itemService.GetAllItems(id).Where(i => i.Status == TodoStatus.Сompleted).ToList());
            if (isneedPageCount)
                list.Insert(0, pages);
            
            return list;
        }
        
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
        
        [HttpPut]
        public HttpResponseMessage UpdateItem(int id, [FromBody]TodoItemViewModel item)
        {
            try
            {
                var itemToUpdate = EntityConvert<TodoItemViewModel, TodoItemModel>(item);
                _itemService.Update(itemToUpdate);
                return Request.CreateResponse(HttpStatusCode.OK, item);
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
