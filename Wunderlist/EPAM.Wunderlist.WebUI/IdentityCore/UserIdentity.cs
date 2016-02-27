using Microsoft.AspNet.Identity;

namespace EPAM.Wunderlist.WebUI.IdentityCore
{
    public class UserIdentity : IUser<int>
    {
        public UserIdentity(int id = 0)
        {
            Id = id;
        }

        public int Id { get; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}