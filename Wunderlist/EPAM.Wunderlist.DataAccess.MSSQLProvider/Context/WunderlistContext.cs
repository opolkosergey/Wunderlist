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

        public DbSet<UserModel> Users { get; set; }
        public DbSet<UserProfileModel> UserProfiles { get; set; }
        public DbSet<TodoListModel> TodoLists { get; set; }
        public DbSet<TodoItemModel> TodoItems { get; set; }
        public DbSet<LogModel> Logs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UserModelConfig());
            modelBuilder.Configurations.Add(new UserProfileModelConfig());
            modelBuilder.Configurations.Add(new TodoItemModelConfig());
            modelBuilder.Configurations.Add(new TodoListModelConfig());

            base.OnModelCreating(modelBuilder);
        }
    }
}
