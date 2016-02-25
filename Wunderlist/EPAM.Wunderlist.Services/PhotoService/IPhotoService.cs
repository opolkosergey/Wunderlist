namespace EPAM.Wunderlist.Services.PhotoService
{
    public interface IPhotoService
    {
        void AddOrUpdatePhoto(int userId, byte[] photo);
        void RemovePhoto(int userId);
    }
}
