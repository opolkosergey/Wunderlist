using System.Data.Entity.ModelConfiguration;
using EPAM.Wunderlist.Model;

namespace EPAM.Wunderlist.DataAccess.MSSQLProvider.EntitiesConfig
{
    internal class UserProfileModelConfig : EntityTypeConfiguration<UserProfileModel>
    {
        public UserProfileModelConfig()
        {
            ToTable("UserProfile");

            HasKey(p => p.Id);

            HasRequired(p => p.UserModel)
                .WithOptional(p => p.Profile);

            Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(30);
        }
    }
}
