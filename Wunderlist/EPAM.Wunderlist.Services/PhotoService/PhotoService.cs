using System;
using EPAM.Wunderlist.DataAccess.API;
using EPAM.Wunderlist.DataAccess.API.Entities;

namespace EPAM.Wunderlist.Services.PhotoService
{
    public class PhotoService : IPhotoService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<UserProfileDbModel> _profileRepository;

        public PhotoService(IUnitOfWork unitOfWork)
        {
            if(unitOfWork == null)
                throw new ArgumentNullException(nameof(unitOfWork));

            _unitOfWork = unitOfWork;
            _profileRepository = unitOfWork.ProfileRepository;
        }

        public void AddOrUpdatePhoto(int userId, byte[] photo)
        {
            throw new NotImplementedException();
        }

        public void RemovePhoto(int userId)
        {
            throw new NotImplementedException();
        }
    }
}
