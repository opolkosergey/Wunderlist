using System;
using EPAM.Wunderlist.DataAccess.API;
using EPAM.Wunderlist.DataAccess.API.Entities;

namespace EPAM.Wunderlist.Services.UserProfileService
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

        public void ChangeName(int id, string name)
        {
            if(id < 0)
                throw new ArgumentException("The ID parameter is less than zero");

            if(name == null)
                throw new ArgumentNullException(nameof(name));

            var profile = _profileRepository.GetById(id);
            
            if (profile != null)
            { 
                profile.Name = name;
                _profileRepository.Update(profile);
                _unitOfWork.Commit();
            }
        }

        public UserProfileModel GetProfile(int userId)
        {
            if (userId < 0)
                throw new ArgumentException("The ID parameter is less than zero");

            return _profileRepository.GetById(userId);
        }
    }
}
