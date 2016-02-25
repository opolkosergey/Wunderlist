using EPAM.Wunderlist.DataAccess.API.Entities;

namespace EPAM.Wunderlist.Services.UserService
{
    public interface IUserService
    {
        void Add(UserModel user);
        UserModel GetUser(int id);
        void Remove(int id);
        void Update(UserModel user); // PUT (думаю внутри должен вызываться метод IUserProfile.ChangeName)
    }
}
