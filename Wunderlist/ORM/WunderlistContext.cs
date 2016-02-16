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

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<TodoList> TodoLists { get; set; }
        public virtual DbSet<TodoItem> TodoItems { get; set; } 
    }
}
