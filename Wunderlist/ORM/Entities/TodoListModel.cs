using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ORM.Entities
{
    public class TodoListModel : IEntityDb
    {
        public TodoListModel()
        {
            TodoItems = new List<TodoItemModel>();
        }

        public int ID { get; set; }
        public int UserID { get; set; }

        [Required]
        [MaxLength(255)]
        public string Name { get; set; }

        public virtual ICollection<TodoItemModel> TodoItems { get; set; }
    }
}
