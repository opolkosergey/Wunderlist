using DAL.Entities;

namespace BLL.Interfaces
{
    public interface IUserProfileService
    {
        UserProfileModel GetProfile(int userId);
        void ChangeName(int id);
    }
}
