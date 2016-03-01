using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EPAM.Wunderlist.Services.Infrastructure.ServiceObjects;
using EPAM.Wunderlist.Services.TodoListsService;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            var item = new TodoListServiceObject
            {
                ID = 3,
                UserID = 15,
                Name = "Default",
                
                TodoItems = new List<TodoItemServiceObject>
                {
                    //new TodoItemServiceObject()
                    //{
                        //ID = 2,
                        //TodoListId = 3,
                        //TodoTask = "DefaultTask",
                        //Date = DateTime.Now,
                        //Description = "Description",
                        //Status = 2,
                    //}
                }
            };

            TodoListsService _service = new TodoListsService(null, null);
            _service.Add(item);
        }
    }
}
