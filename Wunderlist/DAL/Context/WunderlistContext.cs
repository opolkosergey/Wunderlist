using System.Data.Entity;
using DAL.Entities;

namespace DAL.Context
{
    public class WunderlistContext : DbContext
    {
        // !!!Use this static constructor ONLY during development and testing 
        static WunderlistContext()
        {
            Database.SetInitializer(new ContextInitializer());
        }

        public WunderlistContext() : base("name=WunderlistDB") {}

        public DbSet<UserModel> Users { get; set; }
        public DbSet<UserProfileModel> UserProfiles { get; set; }
        public DbSet<TodoListModel> TodoLists { get; set; }
        public DbSet<TodoItemModel> TodoItems { get; set; }
        public DbSet<LogEntity> Logs { get; set; }
    }
}
