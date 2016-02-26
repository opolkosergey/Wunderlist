using EPAM.Wunderlist.DataAccess.API.Entities;

namespace EPAM.Wunderlist.Services.UserProfileService
{
    public interface IUserProfileService
    {
        UserProfileModel GetProfile(int userId);
        void ChangeName(int id, string name);
    }
}
