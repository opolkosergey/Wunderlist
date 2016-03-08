using System.Collections.Generic;

namespace EPAM.Wunderlist.Model
{
    public class TodoListModel : IEntityModel
    {
        public TodoListModel()
        {
            TodoItems = new List<TodoItemModel>();
        }

        public int Id { get; protected set; }
        public int UserModelId { get; set; }
        public string Name { get; set; }
        public int CountItem => TodoItems.Count;

        public virtual UserModel UserModel { get; set; }
        public virtual ICollection<TodoItemModel> TodoItems { get; set; }
    }
}
