using System.Linq;
using EPAM.Wunderlist.DataAccess.API.Entities;

namespace EPAM.Wunderlist.Services.TodoListsService
{
    public interface ITodoListsService
    {
        IQueryable<TodoListDbModel> GetAllTodoLists(int userId);
        void Add(TodoListDbModel list);
        void Remove(int id);
        void Rename(int id, string newName);
    }
}
