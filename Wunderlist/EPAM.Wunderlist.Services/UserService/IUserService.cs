using EPAM.Wunderlist.Model;

namespace EPAM.Wunderlist.Services.UserService
{
    public interface IUserService : IBaseService<UserModel>
    {
        void CreateUser(UserModel user, string name);
        UserModel GetUserByEmail(string email);
    }
}
