using System;
using BLL.Interfaces;
using DAL.Entities;
using DAL.Interfaces;

namespace BLL.Services
{
    public class UserProfileService : IUserProfileService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<UserProfileModel> _profileRepository;

        public UserProfileService(IUnitOfWork unitOfWork)
        {
            if (unitOfWork == null)
                throw new ArgumentNullException(nameof(unitOfWork));

            _unitOfWork = unitOfWork;
            _profileRepository = unitOfWork.ProfileRepository;
        }

        public void ChangeName(int id)
        {
            throw new NotImplementedException();
        }

        public UserProfileModel GetProfile(int userId)
        {
            throw new NotImplementedException();
        }
    }
}
