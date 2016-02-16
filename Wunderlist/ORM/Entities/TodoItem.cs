using System;

namespace ORM.Entities
{
    public enum TodoStatus
    {
        New,
        Unfinished,
        Сompleted
    }

    public class TodoItem : IEntityDb
    {
        public int ID { get; set; }
        public int TodoListId { get; set; }
        public string TodoTask { get; set; }
        public DateTime? Date { get; set; }
        public string Description { get; set; }
        public TodoStatus Status { get; set; }
    }
}
