using System.Data.Entity;
using DAL.Entities;

namespace DAL.Repositories
{
    public class TodoItemRepository : BaseRepository<TodoItemModel>
    {
        public TodoItemRepository(DbContext context) : base(context) {}
    }
}
