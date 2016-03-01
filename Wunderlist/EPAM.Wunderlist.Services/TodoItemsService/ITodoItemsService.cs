using System;
using System.Collections.Generic;
using EPAM.Wunderlist.DataAccess.API.Entities;
using EPAM.Wunderlist.Services.Infrastructure.ServiceObjects;

namespace EPAM.Wunderlist.Services.TodoItemsService
{
    public interface ITodoItemsService
    {
        IEnumerable<TodoItemServiceObject> GetAllItems(int listTodoId);
        void Add(TodoItemServiceObject item);
        void Rename(int id, string newTitle);
        void Remove(int id);
        void SetTodoStatus(int id, TodoStatus status);
        void SetDueDate(int id, DateTime date);
        void RemoveDueDate(int id);
        void AddComment(int id, string description);
        void RemoveComment(int id);
        void MoveItem(int id, int listTodoId);
    }
}
