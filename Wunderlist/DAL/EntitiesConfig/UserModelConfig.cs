using System.Data.Entity.ModelConfiguration;
using DAL.Entities;

namespace DAL.EntitiesConfig
{
    class UserModelConfig : EntityTypeConfiguration<UserModel>
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
