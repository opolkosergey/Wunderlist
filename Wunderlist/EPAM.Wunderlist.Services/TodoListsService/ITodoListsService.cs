using System.Linq;
using EPAM.Wunderlist.DataAccess.API.Entities;

namespace EPAM.Wunderlist.Services.TodoListsService
{
    public interface ITodoListsService
    {
        IQueryable<TodoListModel> GetAllTodoLists(int userId);
        void Add(TodoListModel list);
        void Remove(int id);
        void Rename(int id, string newName);
    }
}
