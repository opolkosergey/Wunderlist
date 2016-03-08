using System;
using System.Data.Entity;
using EPAM.Wunderlist.DataAccess.API;
using EPAM.Wunderlist.DataAccess.MSSQLProvider.Repositories;
using EPAM.Wunderlist.Model;

namespace EPAM.Wunderlist.DataAccess.MSSQLProvider
{
    public class MssqlWorker : IUnitOfWork
    {
        private readonly DbContext _context;

        public MssqlWorker(DbContext context)
        {
            if(context == null)
                throw new ArgumentNullException(nameof(context));
            
            _context = context;
            ItemRepository = new TodoItemRepository(context);
            ListRepository = new TodoListRepository(context);
            ProfileRepository = new UserProfileRepository(context);
            UserRepository = new UserRepository(context);
            LogRepository = new LoggerRepository(context);
        }

        public IRepository<TodoItemModel> ItemRepository { get; }

        public IRepository<TodoListModel> ListRepository { get; }

        public IRepository<UserProfileModel> ProfileRepository { get; }

        public IRepository<UserModel> UserRepository { get; }

        public IRepository<LogModel> LogRepository { get; } 

        public void Commit()
        {
            _context?.SaveChanges();
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
