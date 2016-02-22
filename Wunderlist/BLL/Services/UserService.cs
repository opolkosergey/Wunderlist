using System;
using BLL.Interfaces;
using DAL.Entities;
using DAL.Interfaces;

namespace BLL.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<UserModel> _userRepository;
        
        public UserService(IUnitOfWork unitOfWork)
        {
            if(unitOfWork == null)
                throw new ArgumentNullException(nameof(unitOfWork));

            _unitOfWork = unitOfWork;
            _userRepository = unitOfWork.UserRepository;
        }

        public void Add(UserModel user)
        {
            if(user == null)
                throw new ArgumentNullException(nameof(user));

            user.Profile = new UserProfileModel();
            _userRepository.Add(user);
            _unitOfWork.Commit();
        }

        public UserModel GetUser(int id)
        {
            if (id < 0)
                return null;

            return _userRepository.GetById(id);
        }

        public void Remove(int id)
        {
            _userRepository.Remove(id);
            _unitOfWork.Commit();
        }

        public void Update(UserModel user)
        {
            throw new NotImplementedException();
        }
    }
}
