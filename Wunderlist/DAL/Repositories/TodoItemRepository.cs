using System.Data.Entity;
using DAL.Entities;

namespace DAL.Repositories
{
    public class TodoItemRepository : BaseRepository<TodoItemModel>
    {
        public TodoItemRepository(DbContext context) : base(context) {}
        public override void Add(TodoItemModel entity, IEntity owner)
        {
            (owner as TodoListModel)?.TodoItems.Add(entity);
        }
    }
}
