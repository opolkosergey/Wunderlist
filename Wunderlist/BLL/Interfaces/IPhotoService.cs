namespace BLL.Interfaces
{
    public interface IPhotoService
    {
        void AddOrUpdatePhoto(int userId, byte[] photo);
        void RemovePhoto(int userId);
    }
}
