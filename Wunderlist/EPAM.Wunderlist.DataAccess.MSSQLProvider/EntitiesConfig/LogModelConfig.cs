using System.Data.Entity.ModelConfiguration;
using EPAM.Wunderlist.Model;

namespace EPAM.Wunderlist.DataAccess.MSSQLProvider.EntitiesConfig
{
    class LogModelConfig : EntityTypeConfiguration<LogModel>
    {
        public LogModelConfig()
        {
            ToTable("LogMessage");

            HasKey(p => p.Id);
        }
    }
}
