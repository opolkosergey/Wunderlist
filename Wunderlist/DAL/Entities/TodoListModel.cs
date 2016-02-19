using System.Collections.Generic;

namespace DAL.Entities
{
    public class TodoListModel : IEntity
    {
        public TodoListModel()
        {
            TodoItems = new List<TodoItemModel>();
        }

        public int ID { get; set; }
        public int UserID { get; set; }
        public string Name { get; set; }

        public virtual ICollection<TodoItemModel> TodoItems { get; set; }
    }
}
