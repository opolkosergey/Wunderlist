using System;
using System.Data.Entity;
using DAL.Entities;
using DAL.Interfaces;

namespace DAL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext _context;

        public UnitOfWork(DbContext context)
        {
            if(context == null)
                throw new ArgumentNullException(nameof(context));
            
            _context = context;

            //Вопрос по внедрению зависимости!!!!!
            ItemRepository = new TodoItemRepository(_context);
            ListRepository = new TodoListRepository(_context);
            ProfileRepository = new UserProfileRepository(_context);
            UserRepository = new UserRepository(_context);
        }

        public IRepository<TodoItemModel> ItemRepository { get; }

        public IRepository<TodoListModel> ListRepository { get; }

        public IRepository<UserProfileModel> ProfileRepository { get; }

        public IRepository<UserModel> UserRepository { get; }

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
