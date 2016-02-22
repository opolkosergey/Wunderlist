using System;
using System.Collections.Generic;
using System.Linq;
using DAL.Entities;

namespace BLL.Interfaces
{
    public interface ITodoItemsService
    {
        IQueryable<TodoItemModel> GetAllItems(int listTodoId);
        void Add(TodoItemModel item);
        void Rename(int id);
        void Remove(int id);
        void SetTodoStatus(int id, TodoStatus status);
        void SetDueDate(int id, DateTime date);
        void RemoveDueDate(int id);
        void AddComment(int id, string description);
        void RemoveComment(int id);
        void MoveItem(int id, int listTodoId);
    }
}
