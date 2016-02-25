using System.Data.Entity.ModelConfiguration;
using EPAM.Wunderlist.DataAccess.API.Entities;

namespace EPAM.Wunderlist.DataAccess.MSSQLProvider.EntitiesConfig
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
