using System;

namespace EPAM.Wunderlist.DataAccess.API.Entities
{
    public class LogModel : IEntity
    {
        public int ID { get; }
        public string Log { get; set; }
        public DateTime Time { get; set; }
    }
}
