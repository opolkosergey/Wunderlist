using System.Collections.Generic;

namespace EPAM.Wunderlist.DataAccess.API.Entities
{
    public class UserDbModel : IEntityDb
    {
        public UserDbModel(int id = 0)
        {
            ID = id;
            TodoLists = new List<TodoListDbModel>();
        }

        public int ID { get; }
        public string Email { get; set; }
        public string Password { get; set; }
        
        public virtual UserProfileDbModel Profile { get; set; }
        public virtual ICollection<TodoListDbModel> TodoLists { get; set; }
    }
}
