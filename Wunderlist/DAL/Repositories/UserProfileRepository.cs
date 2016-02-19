using System.Data.Entity;
using DAL.Entities;

namespace DAL.Repositories
{
    public class UserProfileRepository : BaseRepository<UserProfileModel>
    {
        public UserProfileRepository(DbContext context) : base(context) {}
    }
}
