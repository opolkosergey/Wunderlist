using System;
using DAL.Entities;

namespace BLL.Interfaces
{
    public interface ITodoItemsService
    {
        TodoItemModel GetAllItems(int listTodoId);
        void Add(TodoItemModel item);
        void Rename(int id);
        void Remove(int id);
        void MarkAsСompleted(int id);
        void MarkAsFailed(int id);
        void SetDueDate(int id, DateTime date);
        void RemoveDueDate(int id);
        void AddComment(int id, string description);
        void RemoveComment(int id);
        void MoveItems(int id, int listTodoId);
    }
}
