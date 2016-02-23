using Microsoft.AspNet.Identity;
using Wunderlist.IdentityCore;

namespace Wunderlist
{
    public class WunderlistIdentityUserManager : UserManager<WunderlistIdentityUser, int>
    {
        public WunderlistIdentityUserManager(IUserStore<WunderlistIdentityUser, int> store)
            : base(store)
        {
            UserValidator = new UserValidator<WunderlistIdentityUser, int>(this)
            {
                AllowOnlyAlphanumericUserNames = false,
                RequireUniqueEmail = true
            };
        }
    }
}