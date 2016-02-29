using System;

namespace EPAM.Wunderlist.DataAccess.API.Entities
{
    public class LogDbModel : IEntityDb
    {
        public int ID { get; protected set; }
        public string Log { get; set; }
        public DateTime Time { get; set; }
    }
}
