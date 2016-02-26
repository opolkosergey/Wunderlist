using System;
using System.Data.Entity;
using EPAM.Wunderlist.DataAccess.API;
using EPAM.Wunderlist.DataAccess.API.Entities;
using EPAM.Wunderlist.DataAccess.MSSQLProvider.Repositories;

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

        public IRepository<TodoItemDbModel> ItemRepository { get; }

        public IRepository<TodoListDbModel> ListRepository { get; }

        public IRepository<UserProfileDbModel> ProfileRepository { get; }

        public IRepository<UserDbModel> UserRepository { get; }

        public IRepository<LogDbModel> LogRepository { get; } 

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
