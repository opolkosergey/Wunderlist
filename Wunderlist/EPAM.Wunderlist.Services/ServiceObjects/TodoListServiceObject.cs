using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.Wunderlist.Services.ServiceObjects
{
    public class TodoListServiceObject
    {
        public int ID { get; protected set; }
        public int UserID { get; set; }
        public string Name { get; set; }
        public int Count => TodoItems.Count;
        public ICollection<TodoItemServiceObject> TodoItems { get; set; }
    }
}
