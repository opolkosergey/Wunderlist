using System.Data.Entity;
using EPAM.Wunderlist.Model;

namespace EPAM.Wunderlist.DataAccess.MSSQLProvider.Repositories
{
    public class TodoListRepository : BaseRepository<TodoListModel>
    {
        public TodoListRepository(DbContext context) : base(context){}
    }
}
