using System.Collections.Generic;

namespace EPAM.Wunderlist.DataAccess.API.Entities
{
    public class TodoListDbModel : IEntityDb
    {
        public TodoListDbModel(int id = 0)
        {
            ID = id;
            TodoItems = new List<TodoItemDbModel>();
        }

        public int ID { get; }
        public int UserID { get; set; }
        public string Name { get; set; }
        public virtual UserDbModel UserModel { get; set; }
        public virtual ICollection<TodoItemDbModel> TodoItems { get; set; }
    }
}
