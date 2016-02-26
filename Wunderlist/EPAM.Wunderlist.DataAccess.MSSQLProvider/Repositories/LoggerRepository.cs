using System.Data.Entity;
using EPAM.Wunderlist.DataAccess.API.Entities;

namespace EPAM.Wunderlist.DataAccess.MSSQLProvider.Repositories
{
    public class LoggerRepository : BaseRepository<LogDbModel>
    {
        public LoggerRepository(DbContext context) : base(context) {}
    }
}
