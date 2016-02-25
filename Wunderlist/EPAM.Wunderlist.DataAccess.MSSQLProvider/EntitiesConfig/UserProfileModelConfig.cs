using System.Data.Entity.ModelConfiguration;
using EPAM.Wunderlist.DataAccess.API.Entities;

namespace EPAM.Wunderlist.DataAccess.MSSQLProvider.EntitiesConfig
{
    internal class UserProfileModelConfig : EntityTypeConfiguration<UserProfileModel>
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
