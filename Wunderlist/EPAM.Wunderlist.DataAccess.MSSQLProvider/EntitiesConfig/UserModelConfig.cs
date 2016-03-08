using System.Data.Entity.ModelConfiguration;
using EPAM.Wunderlist.Model;

namespace EPAM.Wunderlist.DataAccess.MSSQLProvider.EntitiesConfig
{
    class UserModelConfig : EntityTypeConfiguration<UserModel>
    {
        public UserModelConfig()
        {
            ToTable("User");

            HasKey(p => p.Id);
            
            Property(p => p.Email)
                .IsRequired()
                .HasMaxLength(30);

            Property(p => p.Password)
                .IsRequired()
                .HasMaxLength(70);
        }
    }
}
