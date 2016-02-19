using System.Data.Entity;
using DAL.Entities;

namespace DAL.Repositories
{
    public class TodoListRepository : BaseRepository<TodoListModel>
    {
        public TodoListRepository(DbContext context) : base(context){}
    }
}
