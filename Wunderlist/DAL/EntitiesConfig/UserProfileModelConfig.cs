using System.Data.Entity.ModelConfiguration;
using DAL.Entities;

namespace DAL.EntitiesConfig
{
    class UserProfileModelConfig : EntityTypeConfiguration<UserProfileModel>
    {
        public UserProfileModelConfig()
        {
            HasKey(p => p.ID);
            
            Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(30);
            
        }
    }
}
