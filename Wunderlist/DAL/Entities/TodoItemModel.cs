using System;

namespace DAL.Entities
{
    public enum TodoStatus
    {
        New,
        Unfinished,
        Сompleted
    }

    public class TodoItemModel : IEntity
    {
        public int ID { get; set; }
        public int TodoListId { get; set; }
        public string TodoTask { get; set; }
        public DateTime? Date { get; set; }
        public string Description { get; set; }
        public TodoStatus Status { get; set; }
    }
}
