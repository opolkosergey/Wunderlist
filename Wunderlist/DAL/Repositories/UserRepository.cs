using System.Data.Entity;
using DAL.Entities;

namespace DAL.Repositories
{
    public class UserRepository : BaseRepository<UserModel>
    {
        public UserRepository(DbContext context) : base(context) {}
    }
}
