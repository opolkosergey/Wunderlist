using System.Data.Entity.ModelConfiguration;
using EPAM.Wunderlist.DataAccess.API.Entities;

namespace EPAM.Wunderlist.DataAccess.MSSQLProvider.EntitiesConfig
{
    class LogModelConfig : EntityTypeConfiguration<LogDbModel>
    {
        public LogModelConfig()
        {
            ToTable("LogMessage");

            HasKey(p => p.ID);
        }
    }
}
