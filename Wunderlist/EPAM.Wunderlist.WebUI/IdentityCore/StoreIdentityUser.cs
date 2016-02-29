using System;
using System.Threading.Tasks;
using EPAM.Wunderlist.Services.ServiceObjects;
using EPAM.Wunderlist.Services.UserService;
using Microsoft.AspNet.Identity;
using static EPAM.Wunderlist.WebUI.Mapper.HelperConvert;

namespace EPAM.Wunderlist.WebUI.IdentityCore
{
    public class StoreIdentityUser : IUserPasswordStore<UserIdentity, int>
    {
        private readonly IUserService _userService;

        public StoreIdentityUser(IUserService userService)
        {
            if (userService == null)
                throw new ArgumentNullException(nameof(userService));

            _userService = userService;
        }

        public Task CreateAsync(UserIdentity user)
        {
            if (user != null)
            {
                return Task.Factory.StartNew(() =>
                {
                    UserServiceObject userToAdd = new UserServiceObject
                    {
                        Email = user.Email,
                        Password = user.Password,
                        UserName = user.UserName
                    };

                    _userService.Add(userToAdd);
                });
            }

            return null;
        }

        public Task<UserIdentity> FindByIdAsync(int userId)
        {
            return Task<UserIdentity>.Factory.StartNew(() =>
            {
                var userModel = _userService.GetUserById(userId);
                return EntityConvert<UserServiceObject, UserIdentity>(userModel);
            });
        }

        public Task<UserIdentity> FindByNameAsync(string userName)
        {
            return Task<UserIdentity>.Factory.StartNew(() =>
            {
                var userServiceObject = _userService.GetUserByEmail(userName);
                var userIdentity = EntityConvert<UserServiceObject, UserIdentity>(userServiceObject);
                return userIdentity;
            });
        }

        public Task UpdateAsync(UserIdentity user)
        {
            return Task.Factory.StartNew(() =>
            {
                if (user != null)
                {
                    var userToUpdate = new UserServiceObject(user.Id)
                    {
                        Email = user.Email,
                        Password = user.Password
                    };

                    _userService.Update(userToUpdate);
                }
            });
        }

        public Task DeleteAsync(UserIdentity user)
        {
            return Task.Factory.StartNew(() =>
            {
                if (user != null)
                    _userService.Remove(user.Id);
            });
        }

        public Task<string> GetPasswordHashAsync(UserIdentity user)
        {
            return Task.Factory.StartNew(() => user?.Password);
        }

        public Task SetPasswordHashAsync(UserIdentity user, string passwordHash)
        {
            return Task.Factory.StartNew(() =>
            {
                if (user != null)
                    user.Password = passwordHash;
            });
        }

        public Task<bool> HasPasswordAsync(UserIdentity user)
        {
            return Task.Factory.StartNew(() => user?.Password != null);
        }

        public void Dispose() {}
    }
}