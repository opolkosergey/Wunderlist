using System;
using EPAM.Wunderlist.DataAccess.API;
using EPAM.Wunderlist.Model;
using EPAM.Wunderlist.Services.LoggerService;

namespace EPAM.Wunderlist.Services.PhotoService
{
    public class PhotoService : BaseService<UserProfileModel>, IPhotoService
    {
        public PhotoService(IUnitOfWork workWithMssql, ILoggerService logger)
            : base(workWithMssql, logger, new[] { "Id", "Name", "UserModel" })
        {
        }

        public void AddOrUpdatePhoto(int userId, byte[] photo)
        {
            throw new NotImplementedException();
        }

        public void RemovePhoto(int userId)
        {
            throw new NotImplementedException();
        }

        protected override IRepository<UserProfileModel> GetRepository
            => WorkWithMssql.ProfileRepository;
    }
}
