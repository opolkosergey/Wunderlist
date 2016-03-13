using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using EPAM.Wunderlist.DataAccess.API;
using EPAM.Wunderlist.Model;
using EPAM.Wunderlist.Services.LoggerService;

namespace EPAM.Wunderlist.Services.TodoItemsService
{
    public class TodoItemsService : BaseService<TodoItemModel>, ITodoItemsService
    {
        protected override IRepository<TodoItemModel> GetRepository
            => WorkWithMssql.ItemRepository;

        public TodoItemsService(IUnitOfWork workWithMssql, ILoggerService logger)
            : base(workWithMssql, logger, new[] { "Id", "TodoList" })
        {
        }

        public IEnumerable<TodoItemModel> GetPage(int listTodoId, int page, int pageSize)
        {
            try
            {
                if (listTodoId < 0)
                    throw new ArgumentException(nameof(listTodoId));

                return GetRepository.GetPage(listTodoId,page,pageSize);
            }
            catch (Exception e)
            {
                Logger.Error(e.Message);
            }

            return Enumerable.Empty<TodoItemModel>().AsQueryable();
        }

        public int CountOfUncompleted(int id)
        {
            return GetRepository.Count(i => i.Status == TodoStatus.Unfinished && i.TodoListId == id);
        }

        public int CountOfUncompleted(Expression<Func<TodoItemModel, bool>> expression)
        {
            return GetRepository.Count(expression);
        }

        public IEnumerable<TodoItemModel> GetAllItems(int listTodoId)
        {
            try
            {
                if (listTodoId < 0)
                    throw new ArgumentException(nameof(listTodoId));

                return GetRepository.GetAll()
                    .Where(list => list.TodoListId == listTodoId);
            }
            catch (Exception e)
            {
                Logger.Error(e.Message);
            }

            return Enumerable.Empty<TodoItemModel>().AsQueryable();
        }
    }
}
