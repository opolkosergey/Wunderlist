using System.Collections.Generic;

namespace EPAM.Wunderlist.Model
{
    public class UserModel : IEntityModel
    {
        public UserModel()
        {
            TodoLists = new List<TodoListModel>();
        }

        public int Id { get; protected set; }
        public string Email { get; set; }
        public string Password { get; set; }
        
        public virtual UserProfileModel Profile { get; set; }
        public virtual ICollection<TodoListModel> TodoLists { get; set; }
    }
}
