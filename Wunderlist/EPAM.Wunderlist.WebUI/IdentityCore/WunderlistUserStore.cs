using System;
using System.Threading.Tasks;
using EPAM.Wunderlist.Model;
using EPAM.Wunderlist.Services.UserService;
using Microsoft.AspNet.Identity;
using static EPAM.Wunderlist.WebUI.Mapper.HelperConvert;

namespace EPAM.Wunderlist.WebUI.IdentityCore
{
    public class WunderlistUserStore : IUserPasswordStore<User, int>
    {
        private readonly IUserService _userService;

        public WunderlistUserStore(IUserService userService)
        {
            if (userService == null)
                throw new ArgumentNullException(nameof(userService));

            _userService = userService;
        }
        
        public Task CreateAsync(User user)
        {
            if (user != null)
            {
                return Task.Factory.StartNew(() =>
                {
                    var userToAdd = EntityConvert<User, UserModel>(user);
                    _userService.CreateUser(userToAdd, user.UserName);
                });
            }

            return null;
        }

        public Task<User> FindByIdAsync(int userId)
        {
            return Task<User>.Factory.StartNew(() =>
            {
                var userModel = _userService.GetById(userId);
                var user = EntityConvert<UserModel, User>(userModel);
                user.UserName = userModel.Profile.Name;
                return user;
            });
        }

        public Task<User> FindByNameAsync(string userName)
        {
            return Task<User>.Factory.StartNew(() =>
            {
                var userModel = _userService.GetUserByEmail(userName);

                if (userModel != null)
                {
                    var user = EntityConvert<UserModel, User>(userModel);
                    user.UserName = userModel.Profile.Name;
                    return user;
                }

                return null;
            });
        }

        public Task UpdateAsync(User user)
        {
            return Task.Factory.StartNew(() =>
            {
                if (user != null)
                {
                    var userToUpdate = EntityConvert<User, UserModel>(user);
                    _userService.Update(userToUpdate);
                }
            });
        }

        public Task DeleteAsync(User user)
        {
            return Task.Factory.StartNew(() =>
            {
                if (user != null)
                    _userService.Remove(user.Id);
            });
        }
        
        public Task<string> GetPasswordHashAsync(User user)
        {
            return Task.Factory.StartNew(() => user?.Password);
        }

        public Task SetPasswordHashAsync(User user, string passwordHash)
        {
            return Task.Factory.StartNew(() =>
            {
                if (user != null)
                    user.Password = passwordHash;
            });
        }

        public Task<bool> HasPasswordAsync(User user)
        {
            return Task.Factory.StartNew(() => user?.Password != null);
        }

        public void Dispose() {}
    }
}