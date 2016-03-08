using System.Data.Entity;
using EPAM.Wunderlist.Model;

namespace EPAM.Wunderlist.DataAccess.MSSQLProvider.Repositories
{
    public class UserRepository : BaseRepository<UserModel>
    {
        public UserRepository(DbContext context) : base(context) {}
    }
}
