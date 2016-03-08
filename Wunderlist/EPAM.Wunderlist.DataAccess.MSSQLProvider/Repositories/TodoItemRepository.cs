using System.Data.Entity;
using EPAM.Wunderlist.Model;

namespace EPAM.Wunderlist.DataAccess.MSSQLProvider.Repositories
{
    public class TodoItemRepository : BaseRepository<TodoItemModel>
    {
        public TodoItemRepository(DbContext context) : base(context) {}
    }
}
