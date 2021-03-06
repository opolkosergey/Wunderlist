﻿using System;
using EPAM.Wunderlist.Model;

namespace EPAM.Wunderlist.DataAccess.API
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<UserModel> UserRepository { get; }
        IRepository<UserProfileModel> ProfileRepository { get; }
        IRepository<TodoItemModel> ItemRepository { get; }
        IRepository<TodoListModel> ListRepository { get; }
        IRepository<LogModel> LogRepository { get; } 

        void Commit();
    }
}
