using System.Data.Entity.ModelConfiguration;
using EPAM.Wunderlist.Model;

namespace EPAM.Wunderlist.DataAccess.MSSQLProvider.EntitiesConfig
{
    class TodoListModelConfig : EntityTypeConfiguration<TodoListModel>
    {
        public TodoListModelConfig()
        {
            ToTable("TodoList");

            HasKey(p => p.Id);

            Ignore(p => p.CountItem);

            Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(30);
        }
    }
}
