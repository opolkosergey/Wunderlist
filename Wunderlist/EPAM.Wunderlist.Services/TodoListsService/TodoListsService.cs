using System;
using System.Collections.Generic;
using System.Linq;
using EPAM.Wunderlist.DataAccess.API;
using EPAM.Wunderlist.DataAccess.API.Entities;
using EPAM.Wunderlist.Services.Infrastructure.ServiceObjects;
using EPAM.Wunderlist.Services.LoggerService;
using static EPAM.Wunderlist.Services.Infrastructure.Mapper.HelperConvert;

namespace EPAM.Wunderlist.Services.TodoListsService
{
    public class TodoListsService : ITodoListsService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<TodoListDbModel> _listRepository;
        private readonly ILoggerService _logger;

        public TodoListsService(IUnitOfWork unitOfWork, ILoggerService logger)
        {
            if (unitOfWork == null)
              throw new ArgumentNullException(nameof(unitOfWork));

            _unitOfWork = unitOfWork;
            _listRepository = unitOfWork.ListRepository;
            _logger = logger;
        }

        public IEnumerable<TodoListServiceObject> GetAllTodoLists(int userId)
        {
            try
            {
                if (userId < 0)
                    throw new ArgumentException(nameof(userId));

                var allUserLists = _listRepository.FindBy(l => l.UserModelID == userId);
                return EntityConvert<TodoListDbModel, TodoListServiceObject>(allUserLists);
            }
            catch (Exception e)
            {
                _logger.Error(e.Message);
            }
            return Enumerable.Empty<TodoListServiceObject>().AsQueryable();
        }

        public int Add(TodoListServiceObject list)
        {
            try
            {
                if(list == null)
                    throw new ArgumentNullException(nameof(list));

                if(string.IsNullOrEmpty(list.Name))
                    throw new ArgumentException(nameof(list));

                var listToAdd = EntityConvert<TodoListServiceObject, TodoListDbModel>(list);
                _listRepository.Add(listToAdd);
                _unitOfWork.Commit();
                return listToAdd.ID;
            }
            catch (Exception e)
            {
                _logger.Error(e.Message);   
            }
            return -1;
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
