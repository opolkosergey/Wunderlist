using System.Data.Entity;
using EPAM.Wunderlist.DataAccess.API.Entities;

namespace EPAM.Wunderlist.DataAccess.MSSQLProvider.Repositories
{
    public class UserProfileRepository : BaseRepository<UserProfileDbModel>
    {
        public UserProfileRepository(DbContext context) : base(context) {}
    }
}
