using System.Collections.Generic;

namespace ORM.Entities
{
    public class TodoList : IEntityDb
    {
        public TodoList()
        {
            TodoItems = new List<TodoItem>();
        }

        public int ID { get; set; }
        public int UserID { get; set; }
        public string Name { get; set; }

        public virtual ICollection<TodoItem> TodoItems { get; set; }
    }
}
