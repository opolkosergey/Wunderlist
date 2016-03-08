using System.Data.Entity;
using EPAM.Wunderlist.Model;

namespace EPAM.Wunderlist.DataAccess.MSSQLProvider.Repositories
{
    public class LoggerRepository : BaseRepository<LogModel>
    {
        public LoggerRepository(DbContext context) : base(context) {}
    }
}
