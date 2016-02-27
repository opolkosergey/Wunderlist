using System;
using EPAM.Wunderlist.DataAccess.API.Entities;

namespace EPAM.Wunderlist.DataAccess.API
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<UserDbModel> UserRepository { get; }
        IRepository<UserProfileDbModel> ProfileRepository { get; }
        IRepository<TodoItemDbModel> ItemRepository { get; }
        IRepository<TodoListDbModel> ListRepository { get; }
        IRepository<LogDbModel> LogRepository { get; } 

        void Commit();
    }
}
