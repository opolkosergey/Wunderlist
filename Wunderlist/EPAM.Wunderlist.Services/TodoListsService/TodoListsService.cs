using System;
using System.Collections.Generic;
using System.Linq;
using EPAM.Wunderlist.DataAccess.API;
using EPAM.Wunderlist.Model;
using EPAM.Wunderlist.Services.LoggerService;

namespace EPAM.Wunderlist.Services.TodoListsService
{
    public class TodoListsService : BaseService<TodoListModel>, ITodoListsService
    {
        protected override IRepository<TodoListModel> GetRepository
            => WorkWithMssql.ListRepository;

        public TodoListsService(IUnitOfWork workWithMssql, ILoggerService logger)
            : base(workWithMssql, logger, new []{ "Id", "UserModel", "TodoItems" })
        {
        }

        public IEnumerable<TodoListModel> GetAllTodoLists(int userId)
        {
            try
            {
                if (userId < 0)
                    throw new ArgumentException(nameof(userId));

                return GetRepository.FindBy(list => list.UserModelId == userId);
            }
            catch (Exception e)
            {
                Logger.Error(e.Message);
            }
            return Enumerable.Empty<TodoListModel>().AsQueryable();
        }

        public override void Add(TodoListModel list)
        {
            if (string.IsNullOrEmpty(list.Name))
                return;

            base.Add(list);
        }
    }
}
