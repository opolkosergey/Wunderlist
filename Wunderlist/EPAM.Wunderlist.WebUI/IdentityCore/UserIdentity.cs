using Microsoft.AspNet.Identity;

namespace EPAM.Wunderlist.WebUI.IdentityCore
{
    public class UserIdentity : IUser<int>
    {
        public int Id { get; protected set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}