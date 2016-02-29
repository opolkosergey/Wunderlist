using System;

namespace EPAM.Wunderlist.DataAccess.API.Entities
{
    public enum TodoStatus
    {
        New,
        Unfinished,
        Сompleted
    }

    public class TodoItemDbModel : IEntityDb
    {
        public int ID { get; protected set; }
        public int TodoListId { get; set; }
        public string TodoTask { get; set; }
        public DateTime? Date { get; set; }
        public string Description { get; set; }
        public TodoStatus Status { get; set; }
        public virtual TodoListDbModel TodoList { get; set; }
    }
}
