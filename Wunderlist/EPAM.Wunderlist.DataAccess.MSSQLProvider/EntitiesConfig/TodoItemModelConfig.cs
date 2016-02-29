using System.Data.Entity.ModelConfiguration;
using EPAM.Wunderlist.DataAccess.API.Entities;

namespace EPAM.Wunderlist.DataAccess.MSSQLProvider.EntitiesConfig
{
    public class TodoItemModelConfig : EntityTypeConfiguration<TodoItemDbModel>
    {
        public TodoItemModelConfig()
        {
            ToTable("TodoItem");

            HasKey(p => p.ID);

            Property(p => p.Description)
                .HasMaxLength(255);

            Property(p => p.TodoTask)
                .IsRequired()
                .HasMaxLength(255);
        }
    }
}
