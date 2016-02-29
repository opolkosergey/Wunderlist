using System.Data.Entity;
using EPAM.Wunderlist.DataAccess.API.Entities;
using EPAM.Wunderlist.DataAccess.MSSQLProvider.EntitiesConfig;

namespace EPAM.Wunderlist.DataAccess.MSSQLProvider.Context
{
    public class WunderlistContext : DbContext
    {
        // !!!Use this static constructor ONLY during development and testing 
        static WunderlistContext()
        {
            Database.SetInitializer(new ContextInitializer());
        }

        public WunderlistContext(string connect) : base(connect) {}

        public DbSet<UserDbModel> Users { get; set; }
        public DbSet<UserProfileDbModel> UserProfiles { get; set; }
        public DbSet<TodoListDbModel> TodoLists { get; set; }
        public DbSet<TodoItemDbModel> TodoItems { get; set; }
        public DbSet<LogDbModel> Logs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UserModelConfig());
            modelBuilder.Configurations.Add(new UserProfileModelConfig());
            modelBuilder.Configurations.Add(new TodoItemModelConfig());
            modelBuilder.Configurations.Add(new TodoListModelConfig());
            modelBuilder.Configurations.Add(new LogModelConfig());

            base.OnModelCreating(modelBuilder);
        }
    }
}
