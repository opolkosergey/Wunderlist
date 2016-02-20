using System;
using BLL.Interfaces;
using DAL.Entities;
using DAL.Interfaces;

namespace BLL.Services
{
    public class TodoItemsService : ITodoItemsService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<TodoItemModel> _itemsRepository;

        public TodoItemsService(IUnitOfWork unitOfWork)
        {
            if(unitOfWork == null)
                throw new ArgumentNullException(nameof(unitOfWork));

            _unitOfWork = unitOfWork;
            _itemsRepository = unitOfWork.ItemRepository;
        }

        public void Add(TodoItemModel item)
        {
            throw new NotImplementedException();
        }

        public void Rename(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public TodoItemModel GetAllItems(int listTodoId)
        {
            throw new NotImplementedException();
        }

        public void AddComment(int id, string description)
        {
            throw new NotImplementedException();
        }

        public void RemoveComment(int id)
        {
            throw new NotImplementedException();
        }

        public void MarkAsFailed(int id)
        {
            throw new NotImplementedException();
        }

        public void MarkAsСompleted(int id)
        {
            throw new NotImplementedException();
        }

        public void SetDueDate(int id, DateTime date)
        {
            throw new NotImplementedException();
        }

        public void RemoveDueDate(int id)
        {
            throw new NotImplementedException();
        }

        public void MoveItems(int id, int listTodoId)
        {
            throw new NotImplementedException();
        }
    }
}
