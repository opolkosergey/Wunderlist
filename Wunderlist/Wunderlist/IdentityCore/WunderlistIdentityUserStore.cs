using System;
using System.Threading.Tasks;
using BLL.Interfaces;
using Microsoft.AspNet.Identity;

namespace Wunderlist.IdentityCore
{
    public class WunderlistIdentityUserStore : IUserPasswordStore<WunderlistIdentityUser, int>, IUserEmailStore<WunderlistIdentityUser, int>
    {
        private readonly IUserService _userService;

        public WunderlistIdentityUserStore(IUserService userService)
        {
            if(userService == null)
                throw new ArgumentNullException(nameof(userService));

            _userService = userService;
        }

        public Task CreateAsync(WunderlistIdentityUser user)
        {
            throw new NotImplementedException();
        }

        public Task<WunderlistIdentityUser> FindByIdAsync(int userId)
        {
            throw new NotImplementedException();
        }

        public Task<WunderlistIdentityUser> FindByNameAsync(string userName)
        {
            throw new NotImplementedException();
        }

        public Task<WunderlistIdentityUser> FindByEmailAsync(string email)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(WunderlistIdentityUser user)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(WunderlistIdentityUser user)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetPasswordHashAsync(WunderlistIdentityUser user)
        {
            throw new NotImplementedException();
        }

        public Task SetPasswordHashAsync(WunderlistIdentityUser user, string passwordHash)
        {
            throw new NotImplementedException();
        }

        public Task<bool> HasPasswordAsync(WunderlistIdentityUser user)
        {
            throw new NotImplementedException();
        }
        
        public Task<string> GetEmailAsync(WunderlistIdentityUser user)
        {
            throw new NotImplementedException();
        }

        public Task<bool> GetEmailConfirmedAsync(WunderlistIdentityUser user)
        {
            throw new NotImplementedException();
        }

        public Task SetEmailAsync(WunderlistIdentityUser user, string email)
        {
            throw new NotImplementedException();
        }

        public Task SetEmailConfirmedAsync(WunderlistIdentityUser user, bool confirmed)
        {
            throw new NotImplementedException();
        }
        
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}