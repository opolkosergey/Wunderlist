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

        public DbSet<User> Users { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<TodoList> TodoLists { get; set; }
        public DbSet<TodoItem> TodoItems { get; set; }
    }
}
