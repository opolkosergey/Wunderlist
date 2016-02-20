namespace BLL.Interfaces
{
    public interface IPhotoService
    {
        void ChangePhoto(int userId, byte[] photo);
        void RemovePhoto(int userId);
    }
}
