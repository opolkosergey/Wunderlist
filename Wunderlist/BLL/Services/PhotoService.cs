using System;
using BLL.Interfaces;
using DAL.Entities;
using DAL.Interfaces;

namespace BLL.Services
{
    public class PhotoService : IPhotoService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<UserProfileModel> _profileRepository;

        public PhotoService(IUnitOfWork unitOfWork)
        {
            if(unitOfWork == null)
                throw new ArgumentNullException(nameof(unitOfWork));

            _unitOfWork = unitOfWork;
            _profileRepository = unitOfWork.ProfileRepository;
        }

        public void ChangePhoto(int userId, byte[] photo)
        {
            throw new NotImplementedException();
        }

        public void RemovePhoto(int userId)
        {
            throw new NotImplementedException();
        }
    }
}
