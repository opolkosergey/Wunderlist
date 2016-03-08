using System.Collections.Generic;
using EPAM.Wunderlist.Model;

namespace EPAM.Wunderlist.Services.TodoItemsService
{
    public interface ITodoItemsService : IBaseService<TodoItemModel>
    {
        IEnumerable<TodoItemModel> GetAllItems(int listTodoId);
    }
}
