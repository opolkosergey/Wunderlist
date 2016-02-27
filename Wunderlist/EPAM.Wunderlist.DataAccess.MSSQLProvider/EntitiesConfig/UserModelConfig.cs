using System.Data.Entity.ModelConfiguration;
using EPAM.Wunderlist.DataAccess.API.Entities;

namespace EPAM.Wunderlist.DataAccess.MSSQLProvider.EntitiesConfig
{
    class UserModelConfig : EntityTypeConfiguration<UserDbModel>
    {
        public UserModelConfig()
        {
            HasKey(p => p.ID);
            
            Property(p => p.Email)
                .IsRequired()
                .HasMaxLength(30);

            Property(p => p.Password)
                .IsRequired()
                .HasMaxLength(70);
        }
    }
}
