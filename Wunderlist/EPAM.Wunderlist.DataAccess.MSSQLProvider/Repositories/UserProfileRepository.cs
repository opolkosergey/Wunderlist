using System.Data.Entity;
using EPAM.Wunderlist.Model;

namespace EPAM.Wunderlist.DataAccess.MSSQLProvider.Repositories
{
    public class UserProfileRepository : BaseRepository<UserProfileModel>
    {
        public UserProfileRepository(DbContext context) : base(context) {}
    }
}
