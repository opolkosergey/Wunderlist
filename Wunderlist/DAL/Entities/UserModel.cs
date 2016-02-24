using System.Collections.Generic;

namespace DAL.Entities
{
    public class UserModel : IEntity
    {
        public UserModel()
        {
            TodoLists = new List<TodoListModel>();
        }

        public int ID { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        
        public virtual UserProfileModel Profile { get; set; }
        public virtual ICollection<TodoListModel> TodoLists { get; set; }
    }
}
