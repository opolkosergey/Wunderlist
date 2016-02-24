using System;
using System.ComponentModel.DataAnnotations;

namespace ORM.Entities
{
    public enum TodoStatus
    {
        New,
        Unfinished,
        Сompleted
    }

    public class TodoItemModel : IEntityDb
    {
        public int ID { get; set; }
        public int TodoListId { get; set; }

        [Required]
        [MaxLength(255)]
        public string TodoTask { get; set; }
        public DateTime? Date { get; set; }
        public string Description { get; set; }

        [Required]
        public TodoStatus Status { get; set; }
    }
}
