using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ORM.Entities
{
    public class UserModel : IEntityDb
    {
        public UserModel()
        {
            TodoLists = new List<TodoListModel>();
        }

        public int ID { get; set; }

        [Required]
        [MaxLength(30)]
        public string Email { get; set; }

        [Required]
        [MaxLength(30)]
        public string Password { get; set; }
        
        public virtual UserProfileModel Profile { get; set; }
        public virtual ICollection<TodoListModel> TodoLists { get; set; }
    }
}
