using EPAM.Wunderlist.WebUI.IdentityCore;
using Microsoft.AspNet.Identity;

namespace EPAM.Wunderlist.WebUI
{
    public class ManagerIdentityUser : UserManager<User, int>
    {
        public ManagerIdentityUser(IUserPasswordStore<User, int> store)
            : base(store)
        {
            UserValidator = new UserValidator<User, int>(this)
            {
                AllowOnlyAlphanumericUserNames = false,
                //RequireUniqueEmail = true
            };
        }
    }
}