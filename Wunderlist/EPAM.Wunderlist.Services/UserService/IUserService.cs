using EPAM.Wunderlist.Services.ServiceObjects;

namespace EPAM.Wunderlist.Services.UserService
{
    public interface IUserService
    {
        void Add(UserServiceObject user);
        UserServiceObject GetUser(int id);
        void Remove(int id);
        void Update(UserServiceObject user); // PUT (думаю внутри должен вызываться метод IUserProfile.ChangeName)
    }
}
