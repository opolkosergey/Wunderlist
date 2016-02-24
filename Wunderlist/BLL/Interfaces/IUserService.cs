using System;
using DAL.Entities;

namespace BLL.Interfaces
{
    public interface IUserService
    {
        void Add(UserModel user);
        UserModel GetUser(int id);
        void Remove(int id);
        void Update(UserModel user); // PUT (думаю внутри должен вызываться метод IUserProfile.ChangeName)
    }
}
