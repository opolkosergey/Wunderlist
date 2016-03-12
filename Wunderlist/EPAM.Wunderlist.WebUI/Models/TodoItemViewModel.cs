using System;

namespace EPAM.Wunderlist.WebUI.Models
{
    public class TodoItemViewModel
    {
        public int Id { get; set; }
        public int TodoListId { get; set; }
        public string TodoTask { get; set; }
        public DateTime? Date { get; set; }
        public string Description { get; set; }
        public int Status { get; set; }
    }
}