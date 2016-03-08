using System.Collections.Generic;
using EPAM.Wunderlist.Model;

namespace EPAM.Wunderlist.Services.TodoListsService
{
    public interface ITodoListsService : IBaseService<TodoListModel>
    {
        IEnumerable<TodoListModel> GetAllTodoLists(int userId);
    }
}
