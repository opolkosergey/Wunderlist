using System;
using System.Data.Entity;
using DAL.Entities;
using DAL.Interfaces;

namespace DAL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext _context;

        public UnitOfWork(DbContext context, IRepository<TodoItemModel> itemRepository,
            IRepository<TodoListModel> listRepository, IRepository<UserProfileModel> profileRepository,
            IRepository<UserModel> userRepository)
        {
            if(context == null)
                throw new ArgumentNullException(nameof(context));

            if(itemRepository == null)
                throw new ArgumentNullException(nameof(itemRepository));

            if (listRepository == null)
                throw new ArgumentNullException(nameof(listRepository));

            if (profileRepository == null)
                throw new ArgumentNullException(nameof(profileRepository));

            if (userRepository == null)
                throw new ArgumentNullException(nameof(userRepository));

            _context = context;
            ItemRepository = itemRepository;
            ListRepository = listRepository;
            ProfileRepository = profileRepository;
            UserRepository = userRepository;
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
