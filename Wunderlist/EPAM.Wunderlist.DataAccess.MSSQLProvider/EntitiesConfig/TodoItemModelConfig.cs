using System.Data.Entity.ModelConfiguration;
using EPAM.Wunderlist.Model;

namespace EPAM.Wunderlist.DataAccess.MSSQLProvider.EntitiesConfig
{
    public class TodoItemModelConfig : EntityTypeConfiguration<TodoItemModel>
    {
        public TodoItemModelConfig()
        {
            ToTable("TodoItem");

            HasKey(p => p.Id);

            Property(p => p.Description)
                .HasMaxLength(255);

            Property(p => p.TodoTask)
                .IsRequired()
                .HasMaxLength(255);
        }
    }
}
