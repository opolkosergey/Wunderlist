using System;
using DAL.Entities;

namespace DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<UserModel> UserRepository { get; }
        IRepository<UserProfileModel> ProfileRepository { get; }
        IRepository<TodoItemModel> ItemRepository { get; }
        IRepository<TodoListModel> ListRepository { get; }

        void Commit();
    }
}
