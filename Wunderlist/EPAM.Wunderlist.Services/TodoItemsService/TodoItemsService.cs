using System;
using System.Data.Common;
using System.Linq;
using EPAM.Wunderlist.DataAccess.API;
using EPAM.Wunderlist.DataAccess.API.Entities;
using EPAM.Wunderlist.Services.LoggerService;

namespace EPAM.Wunderlist.Services.TodoItemsService
{
    public class TodoItemsService : ITodoItemsService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<TodoItemDbModel> _itemsRepository;
        private readonly ILoggerService _logger;

        public TodoItemsService(IUnitOfWork unitOfWork, ILoggerService logger)
        {
            if(unitOfWork == null)
                throw new ArgumentNullException(nameof(unitOfWork));

            _unitOfWork = unitOfWork;
            _itemsRepository = unitOfWork.ItemRepository;
            _logger = logger;
        }

        IQueryable<TodoItemDbModel> ITodoItemsService.GetAllItems(int listTodoId)
        {
            try
            {
                if (listTodoId < 0)
                    throw new ArgumentException(nameof(listTodoId));
                return _itemsRepository.GetAll().Where(i => i.TodoListId == listTodoId);
            }
            catch (Exception e)
            {
                _logger.Error(e.Message);
            }
            return Enumerable.Empty<TodoItemDbModel>().AsQueryable(); ;
        }

        public void Add(TodoItemDbModel item)
        {
            try
            {
                if(item.TodoListId < 0)
                    throw new ArgumentException(nameof(item.TodoListId));
                _itemsRepository.Add(item);
                _unitOfWork.Commit();
            }
            catch (ArgumentException e)
            {
                _logger.Warn(e.Message);
            }
            catch (Exception e)
            {
                _logger.Error(e.Message);
            }
        }

        public void Rename(int id, string newTitle)
        {
            try
            {
                if (id < 0)
                    throw new ArgumentException(nameof(id));
                if (string.IsNullOrEmpty(newTitle))
                    throw new ArgumentException(nameof(newTitle));
                var entity = _itemsRepository.GetById(id);
                entity.TodoTask = newTitle;
                _itemsRepository.Update(entity);
                _unitOfWork.Commit();
            }
            catch (Exception e)
            {
                _logger.Error(e.Message);
            }
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
            catch (Exception e)
            {
                _logger.Error(e.Message);
            }
        }

        public void AddComment(int id, string description)
        {
            try
            {
                if (id < 0)
                    throw new ArgumentException(nameof(id));
                var item = _itemsRepository.GetById(id);
                item.Description = description;
                _itemsRepository.Update(item);
                _unitOfWork.Commit();
            }
            catch (Exception e)
            {
                _logger.Error(e.Message);
            }
        }

        public void RemoveComment(int id) => AddComment(id,String.Empty);

        public void MoveItem(int id, int listTodoId)
        {
            try
            {
                if (id < 0)
                    throw new ArgumentException(nameof(id));
                var item = _itemsRepository.GetById(id);
                item.TodoListId = listTodoId;
                _itemsRepository.Update(item);
                _unitOfWork.Commit();
            }
            catch (Exception e)
            {
                _logger.Error(e.Message);
            }
        }

        public void SetDueDate(int id, DateTime date)
        {
            try
            {
                var item = _itemsRepository.GetById(id);
                item.Date = date;
                _itemsRepository.Update(item);
                _unitOfWork.Commit();
            }
            catch (Exception e)
            {
                _logger.Error(e.Message);
            }
        }

        public void RemoveDueDate(int id)//???
        {
            var item = _itemsRepository.GetById(id);
            item.Date = null;
            _itemsRepository.Update(item);
            _unitOfWork.Commit();
        }
    }
}
