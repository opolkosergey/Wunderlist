using System;
using System.Linq;
using EPAM.Wunderlist.DataAccess.API.Entities;

namespace EPAM.Wunderlist.Services.TodoItemsService
{
    public interface ITodoItemsService
    {
        IQueryable<TodoItemModel> GetAllItems(int listTodoId);
        void Add(TodoItemModel item);
        void Rename(int id, string newTitle);
        void Remove(int id);
        void SetTodoStatus(int id, TodoStatus status);
        void SetDueDate(int id, DateTime date);
        void RemoveDueDate(int id);//нужен вообще? вроде бы нет)
        void AddComment(int id, string description);
        void RemoveComment(int id);
        void MoveItem(int id, int listTodoId);
    }
}
