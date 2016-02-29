using System.Data.Entity.ModelConfiguration;
using EPAM.Wunderlist.DataAccess.API.Entities;

namespace EPAM.Wunderlist.DataAccess.MSSQLProvider.EntitiesConfig
{
    internal class UserProfileModelConfig : EntityTypeConfiguration<UserProfileDbModel>
    {
        public UserProfileModelConfig()
        {
            ToTable("UserProfile");

            HasKey(p => p.ID);

            HasRequired(p => p.UserModel)
                .WithOptional(p => p.Profile);

            Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(30);

        }
    }
}
