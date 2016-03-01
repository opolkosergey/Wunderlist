using System;

namespace EPAM.Wunderlist.Services.Infrastructure.ServiceObjects
{
    public class TodoItemServiceObject
    {
        public int ID { get; set; }
        public int TodoListId { get; set; }
        public string TodoTask { get; set; }
        public DateTime? Date { get; set; }
        public string Description { get; set; }
        public int Status { get; set; }
    }
}
