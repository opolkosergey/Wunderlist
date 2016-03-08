using System;

namespace EPAM.Wunderlist.Model
{
    public enum TodoStatus
    {
        New,
        Unfinished,
        Сompleted
    }

    public class TodoItemModel : IEntityModel
    {
        public int Id { get; protected set; }
        public int TodoListId { get; set; }
        public string TodoTask { get; set; }
        public string Date { get; set; }
        public string Description { get; set; }
        public TodoStatus Status { get; set; }
        public virtual TodoListModel TodoList { get; set; }
    }
}
