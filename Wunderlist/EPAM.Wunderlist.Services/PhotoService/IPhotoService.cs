using EPAM.Wunderlist.Model;

namespace EPAM.Wunderlist.Services.PhotoService
{
    public interface IPhotoService : IBaseService<UserProfileModel>
    {
        void AddOrUpdatePhoto(int userId, byte[] photo);
        void RemovePhoto(int userId);
    }
}
