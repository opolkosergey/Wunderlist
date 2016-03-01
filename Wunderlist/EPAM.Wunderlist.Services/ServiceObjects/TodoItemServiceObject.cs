using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.Wunderlist.Services.ServiceObjects
{
    public class TodoItemServiceObject
    {
        public int ID { get; protected set; }
        public int TodoListId { get; set; }
        public string TodoTask { get; set; }
        public DateTime? Date { get; set; }
        public string Description { get; set; }
        public int Status { get; set; }
    }
}
