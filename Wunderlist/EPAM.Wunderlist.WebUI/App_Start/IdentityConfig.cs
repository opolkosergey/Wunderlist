using EPAM.Wunderlist.WebUI.IdentityCore;
using Microsoft.AspNet.Identity;

namespace EPAM.Wunderlist.WebUI
{
    public class ManagerIdentityUser : UserManager<UserIdentity, int>
    {
        public ManagerIdentityUser(IUserStore<UserIdentity, int> store)
            : base(store)
        {
            UserValidator = new UserValidator<UserIdentity, int>(this)
            {
                AllowOnlyAlphanumericUserNames = false,
                //RequireUniqueEmail = true
            };
        }
    }
}