using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using BLL.Interfaces;
using BLL.Loggers;
using DAL.Entities;
using DAL.Interfaces;

namespace BLL.Services
{
    public class TodoItemsService : ITodoItemsService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<TodoItemModel> _itemsRepository;
        private readonly ILogger _logger;

        public TodoItemsService(IUnitOfWork unitOfWork, ILogger logger)
        {
            if(unitOfWork == null)
                throw new ArgumentNullException(nameof(unitOfWork));

            _unitOfWork = unitOfWork;
            _itemsRepository = unitOfWork.ItemRepository;
            _logger = logger;
        }

        IQueryable<TodoItemModel> ITodoItemsService.GetAllItems(int listTodoId)
        {
            try
            {
                if (listTodoId < 0)
                    throw new ArgumentException(nameof(listTodoId));
                return _itemsRepository.GetAll().Where(i => i.TodoListId == listTodoId);
            }
            catch (ArgumentNullException e)
            {
                _logger.Info(e.Message);
            }
            catch (ArgumentException e)
            {
                _logger.Info(e.Message);
            }
            catch (Exception e)
            {
                _logger.Error(e.Message);
            }
            return Enumerable.Empty<TodoItemModel>().AsQueryable(); ;
        }

        public void Add(TodoItemModel item, int listId)
        {
            try
            {
                if (listId < 0)
                    throw new ArgumentException(nameof(listId));
                var owner = _unitOfWork.ListRepository.GetById(listId);
                _itemsRepository.Add(item, owner);
                _unitOfWork.Commit();
            }
            catch (ArgumentException e)
            {
                _logger.Info(e.Message);
            }
            catch (DbUpdateException e)
            {
                _logger.Error(e.Message);
            }
            catch (NotSupportedException e)
            {
                _logger.Error(e.Message);
            }
            catch (Exception e)
            {
                _logger.Error(e.Message);
            }
        }

        public void Rename(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            try
            {
                if(id < 0)
                    throw new ArgumentException(nameof(id));
                _itemsRepository.Remove(id);
                _unitOfWork.Commit();
            }
            catch (ArgumentException e)
            {
                _logger.Info(e.Message);
            }
            catch (DbUpdateException e)
            {
                _logger.Error(e.Message);
            }
            catch (NotSupportedException e)
            {
                _logger.Error(e.Message);
            }
            catch (Exception e)
            {
                _logger.Error(e.Message);
            }
        }

        public void SetTodoStatus(int id, TodoStatus status)
        {
            try
            {
                if (id < 0)
                    throw new ArgumentException(nameof(id));
                var entity = _itemsRepository.GetById(id);
                entity.Status = status;
                _itemsRepository.Update(entity);
                _unitOfWork.Commit();
            }
            catch (ArgumentException e)
            {
                _logger.Info(e.Message);
            }
            catch (Exception e)
            {
                _logger.Error(e.Message);
            }
        }

        public void AddComment(int id, string description)
        {
            var item = _itemsRepository.GetById(id);
            item.Description = description;
            _itemsRepository.Update(item);
            _unitOfWork.Commit();
        }

        public void RemoveComment(int id)
        {
            AddComment(id,String.Empty);
        }

        public void MoveItem(int id, int listTodoId)
        {
            var item = _itemsRepository.GetById(id);
            item.TodoListId = listTodoId;
            _itemsRepository.Update(item);
            _unitOfWork.Commit();
        }

        public void SetDueDate(int id, DateTime date)
        {
            var item = _itemsRepository.GetById(id);
            item.Date = date;
            _itemsRepository.Update(item);
            _unitOfWork.Commit();
        }

        public void RemoveDueDate(int id)
        {
            var item = _itemsRepository.GetById(id);
            item.Date = null;
            _itemsRepository.Update(item);
            _unitOfWork.Commit();
        }

        public void MoveItems(int id, int listTodoId)
        {
            throw new NotImplementedException();
        }
    }
}
