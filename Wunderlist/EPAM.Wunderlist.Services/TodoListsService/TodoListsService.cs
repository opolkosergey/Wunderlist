using System;
using EPAM.Wunderlist.DataAccess.API;
using EPAM.Wunderlist.DataAccess.API.Entities;

namespace EPAM.Wunderlist.Services.TodoListsService
{
    public class TodoListsService : ITodoListsService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<TodoListModel> _listRepository;

        public TodoListsService(IUnitOfWork unitOfWork)
        {
            if (unitOfWork == null)
                throw new ArgumentNullException(nameof(unitOfWork));

            _unitOfWork = unitOfWork;
            _listRepository = unitOfWork.ListRepository;
        }

        public void Add(TodoListModel list)
        {
            throw new NotImplementedException();
        }

        public TodoListModel GetAllСategories(int userId)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(int id)
        {
            throw new NotImplementedException();
        }
    }
}
