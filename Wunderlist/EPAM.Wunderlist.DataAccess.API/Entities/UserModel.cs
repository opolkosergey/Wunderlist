using System.Collections.Generic;

namespace EPAM.Wunderlist.DataAccess.API.Entities
{
    public class UserModel : IEntity
    {
        public UserModel(int id = 0)
        {
            ID = id;
            TodoLists = new List<TodoListModel>();
        }

        public int ID { get; }
        public string Email { get; set; }
        public string Password { get; set; }
        
        public virtual UserProfileModel Profile { get; set; }
        public virtual ICollection<TodoListModel> TodoLists { get; set; }
    }
}
