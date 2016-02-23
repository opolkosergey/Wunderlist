using System.Data.Entity.ModelConfiguration;
using DAL.Entities;

namespace DAL.EntitiesConfig
{
    class TodoItemModelConfig : EntityTypeConfiguration<TodoItemModel>
    {
        public TodoItemModelConfig()
        {
            HasKey(p => p.ID);

            Property(p => p.Description)
                .HasMaxLength(255);

            Property(p => p.TodoTask)
                .IsRequired()
                .HasMaxLength(255);
        }
    }
}
