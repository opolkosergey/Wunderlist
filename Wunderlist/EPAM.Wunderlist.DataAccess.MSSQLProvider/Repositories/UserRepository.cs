using System.Data.Entity;
using EPAM.Wunderlist.DataAccess.API.Entities;

namespace EPAM.Wunderlist.DataAccess.MSSQLProvider.Repositories
{
    public class UserRepository : BaseRepository<UserDbModel>
    {
        public UserRepository(DbContext context) : base(context) {}
    }
}
