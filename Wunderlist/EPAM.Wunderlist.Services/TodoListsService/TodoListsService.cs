using System;
using System.Linq;
using EPAM.Wunderlist.DataAccess.API;
using EPAM.Wunderlist.DataAccess.API.Entities;
using EPAM.Wunderlist.Services.LoggerService;

namespace EPAM.Wunderlist.Services.TodoListsService
{
    public class TodoListsService : ITodoListsService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<TodoListDbModel> _listRepository;
        private readonly ILogger _logger;

        public TodoListsService(IUnitOfWork unitOfWork, ILogger logger)
        {
            if (unitOfWork == null)
                throw new ArgumentNullException(nameof(unitOfWork));

            _unitOfWork = unitOfWork;
            _listRepository = unitOfWork.ListRepository;
            _logger = logger;
        }

        public IQueryable<TodoListDbModel> GetAllTodoLists(int userId)
        {
            try
            {
                if(userId < 0)
                    throw new ArgumentException(nameof(userId));
                return _listRepository.FindBy(l => l.UserID == userId);
            }
            catch (Exception e)
            {
                _logger.Error(e.Message);
            }
            return Enumerable.Empty<TodoListDbModel>().AsQueryable();
        }

        public void Add(TodoListDbModel list)
        {
            try
            {
                if(list == null)
                    throw new ArgumentNullException(nameof(list));
                if(string.IsNullOrEmpty(list.Name))
                    throw new ArgumentException(nameof(list));
                _listRepository.Add(list);
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
                if (id < 0)
                    throw new ArgumentException(nameof(id));
                _listRepository.Remove(id);
                _unitOfWork.Commit();
            }
            catch (Exception e)
            {
                _logger.Error(e.Message);
            }
        }

        public void Rename(int id, string newName)
        {
            try
            {
                if (id < 0)
                    throw new ArgumentException(nameof(id));
                if (string.IsNullOrEmpty(newName))
                    throw new ArgumentException(nameof(newName));
                var entity = _listRepository.GetById(id);
                entity.Name = newName;
                _listRepository.Update(entity);
                _unitOfWork.Commit();
            }
            catch (Exception e)
            {
                _logger.Error(e.Message);
            }
        }
    }
}
