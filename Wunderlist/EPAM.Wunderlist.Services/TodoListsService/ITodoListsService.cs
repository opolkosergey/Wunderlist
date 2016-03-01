using System.Collections.Generic;
using EPAM.Wunderlist.Services.Infrastructure.ServiceObjects;

namespace EPAM.Wunderlist.Services.TodoListsService
{
    public interface ITodoListsService
    {
        IEnumerable<TodoListServiceObject> GetAllTodoLists(int userId);
        void Add(TodoListServiceObject list);
        void Remove(int id);
        void Rename(int id, string newName);
    }
}
