using System;
using System.Threading.Tasks;
using EPAM.Wunderlist.Services.UserService;
using Microsoft.AspNet.Identity;

namespace EPAM.Wunderlist.WebUI.IdentityCore
{
    public class StoreIdentityUser : IUserPasswordStore<UserIdentity, int>, IUserEmailStore<UserIdentity, int>
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
            throw new NotImplementedException();
        }

        public Task<UserIdentity> FindByIdAsync(int userId)
        {
            throw new NotImplementedException();
        }

        public Task<UserIdentity> FindByNameAsync(string userName)
        {
            throw new NotImplementedException();
        }

        public Task<UserIdentity> FindByEmailAsync(string email)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(UserIdentity user)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(UserIdentity user)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetPasswordHashAsync(UserIdentity user)
        {
            throw new NotImplementedException();
        }

        public Task SetPasswordHashAsync(UserIdentity user, string passwordHash)
        {
            throw new NotImplementedException();
        }

        public Task<bool> HasPasswordAsync(UserIdentity user)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetEmailAsync(UserIdentity user)
        {
            throw new NotImplementedException();
        }

        public Task<bool> GetEmailConfirmedAsync(UserIdentity user)
        {
            throw new NotImplementedException();
        }

        public Task SetEmailAsync(UserIdentity user, string email)
        {
            throw new NotImplementedException();
        }

        public Task SetEmailConfirmedAsync(UserIdentity user, bool confirmed)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}