using System.Data.Entity.ModelConfiguration;
using DAL.Entities;

namespace DAL.EntitiesConfig
{
    class TodoListModelConfig : EntityTypeConfiguration<TodoListModel>
    {
        public TodoListModelConfig()
        {
            HasKey(p => p.ID);

            Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(30);
        }
    }
}
