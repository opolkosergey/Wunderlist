using System.Collections.Generic;

namespace EPAM.Wunderlist.DataAccess.API.Entities
{
    public class TodoListModel : IEntity
    {
        public TodoListModel(int id = 0)
        {
            ID = id;
            TodoItems = new List<TodoItemModel>();
        }

        public int ID { get; }
        public int UserID { get; set; }
        public string Name { get; set; }

        public virtual ICollection<TodoItemModel> TodoItems { get; set; }
    }
}
