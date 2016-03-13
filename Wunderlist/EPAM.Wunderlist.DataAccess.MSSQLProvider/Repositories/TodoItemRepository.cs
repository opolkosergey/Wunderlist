using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using EPAM.Wunderlist.Model;

namespace EPAM.Wunderlist.DataAccess.MSSQLProvider.Repositories
{
    public class TodoItemRepository : BaseRepository<TodoItemModel>
    {
        public TodoItemRepository(DbContext context) : base(context) {}

        public override IQueryable<TodoItemModel> GetPage(int listTodoId, int page, int pageSize)
        {
            return _dbSet.Where(i => i.TodoListId == listTodoId && i.Status == TodoStatus.Unfinished)
                .OrderBy(x => x.Id)
                .Skip((page - 1)*pageSize)
                .Take(pageSize);
        }
    }
}
