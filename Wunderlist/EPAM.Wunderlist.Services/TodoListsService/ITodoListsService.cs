using EPAM.Wunderlist.DataAccess.API.Entities;

namespace EPAM.Wunderlist.Services.TodoListsService
{
    public interface ITodoListsService
    {
        TodoListModel GetAllСategories(int userId);
        void Add(TodoListModel list);
        void Remove(int id);
        void Update(int id);
    }
}
