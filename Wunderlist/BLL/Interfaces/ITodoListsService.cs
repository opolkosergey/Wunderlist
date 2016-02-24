using DAL.Entities;

namespace BLL.Interfaces
{
    public interface ITodoListsService
    {
        TodoListModel GetAllСategories(int userId);
        void Add(TodoListModel list);
        void Remove(int id);
        void Update(int id);
    }
}
