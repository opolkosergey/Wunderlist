using System.Data.Entity;
using ORM.Entities;

namespace ORM
{
    public class WunderlistContext : DbContext
    {
        // !!!Use this static constructor ONLY during development and testing 
        static WunderlistContext()
        {
            Database.SetInitializer(new ContextInitializer());
        }

        public WunderlistContext() : base("name=WunderlistDB")
        {

        }

        public DbSet<UserModel> Users { get; set; }
        public DbSet<UserProfileModel> UserProfiles { get; set; }
        public DbSet<TodoListModel> TodoLists { get; set; }
        public DbSet<TodoItemModel> TodoItems { get; set; }
    }
}
