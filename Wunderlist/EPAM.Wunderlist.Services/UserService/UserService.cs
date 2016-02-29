using System;
using System.Linq;
using EPAM.Wunderlist.DataAccess.API;
using EPAM.Wunderlist.DataAccess.API.Entities;
using EPAM.Wunderlist.Services.ServiceObjects;

namespace EPAM.Wunderlist.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<UserDbModel> _userRepository;
        private readonly IRepository<UserProfileDbModel> _profileRepository; 
        
        public UserService(IUnitOfWork unitOfWork)
        {
            if(unitOfWork == null)
                throw new ArgumentNullException(nameof(unitOfWork));

            _unitOfWork = unitOfWork;
            _userRepository = unitOfWork.UserRepository;
            _profileRepository = unitOfWork.ProfileRepository;
        }

        public void Add(UserServiceObject user)
        {
            if(user == null)
                throw new ArgumentNullException(nameof(user));

            UserDbModel userToAdd = new UserDbModel
            {
                Email = user.Email,
                Password = user.Password,
                Profile = new UserProfileDbModel
                {
                    Name = user.UserName
                }
            };
            
            _userRepository.Add(userToAdd);
            _unitOfWork.Commit();
        }

        public UserServiceObject GetUserById(int id)
        {
            if (id < 0)
                return null;

            var userModel = _userRepository.GetById(id);

            if (userModel == null)
                return null;

            var getUser = new UserServiceObject(userModel.ID)
            {
                Password = userModel.Password,
                Email = userModel.Email,
                UserName = userModel.Profile.Name
            };

            return getUser;
        }

        public UserServiceObject GetUserByName(string name)
        {
            if (name == null)
                return null;

            var userModel = _userRepository.GetAll()
                .FirstOrDefault(p => p.Profile.Name == name);

            if (userModel == null)
                return null;

            var getUser = new UserServiceObject(userModel.ID)
            {
                Password = userModel.Password,
                Email = userModel.Email,
                UserName = userModel.Profile.Name
            };

            return getUser;
        }

        public UserServiceObject GetUserByEmail(string email)
        {
            if (email == null)
                return null;

            var userModel = _userRepository.GetAll()
                .FirstOrDefault(p => p.Email == email);

            if (userModel == null)
                return null;

            var getUser = new UserServiceObject(userModel.ID)
            {
                Password = userModel.Password,
                Email = userModel.Email,
                UserName = userModel.Profile.Name
            };

            return getUser;
        }

        public void Remove(int id)
        {
            _userRepository.Remove(id);
            _profileRepository.Remove(id);
            _unitOfWork.Commit();
        }

        public void Update(UserServiceObject user)
        {
            if(user == null)
                throw new ArgumentNullException(nameof(user));

            var userToUpdate = _userRepository.GetById(user.Id);

            if (userToUpdate != null)
            {
                userToUpdate.Email = user.Email;
                userToUpdate.Password = user.Password;

                _userRepository.Update(userToUpdate);
                _unitOfWork.Commit();
            }
        }

        public bool CheckEmail(string email)
        {
            return GetUserByEmail(email) != null;
        }
    }
}
