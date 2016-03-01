using System.Linq;
using EPAM.Wunderlist.Services.Infrastructure.ServiceObjects;

namespace EPAM.Wunderlist.Services.UserService
{
    public interface IUserService
    {
        void Add(UserServiceObject user);
        UserServiceObject GetUserById(int id);
        UserServiceObject GetUserByName(string name);
        UserServiceObject GetUserByEmail(string email);
        bool CheckEmail(string email);
        void Remove(int id);
        void Update(UserServiceObject user);
    }
}
