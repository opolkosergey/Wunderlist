using System.Collections.Generic;

namespace ORM.Entities
{
    public class User : IEntityDb
    {
        public User()
        {
            TodoLists = new List<TodoList>();
        }

        public int ID { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        
        public virtual UserProfile Profile { get; set; }
        public virtual ICollection<TodoList> TodoLists { get; set; }
    }
}
