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
