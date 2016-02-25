using System;

namespace EPAM.Wunderlist.DataAccess.API.Entities
{
    public enum TodoStatus
    {
        New,
        Unfinished,
        Сompleted
    }

    public class TodoItemModel : IEntity
    {
        public TodoItemModel(int id = 0)
        {
            ID = id;
        }

        public int ID { get; }
        public int TodoListId { get; set; }
        public string TodoTask { get; set; }
        public DateTime? Date { get; set; }
        public string Description { get; set; }
        public TodoStatus Status { get; set; }
        public virtual TodoListModel TodoList { get; set; }
    }
}
