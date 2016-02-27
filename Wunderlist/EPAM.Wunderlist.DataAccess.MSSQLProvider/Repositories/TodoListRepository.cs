using System.Data.Entity;
using EPAM.Wunderlist.DataAccess.API.Entities;

namespace EPAM.Wunderlist.DataAccess.MSSQLProvider.Repositories
{
    public class TodoListRepository : BaseRepository<TodoListDbModel>
    {
        public TodoListRepository(DbContext context) : base(context){}
    }
}
