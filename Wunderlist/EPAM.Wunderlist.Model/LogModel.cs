using System;

namespace EPAM.Wunderlist.Model
{
    public class LogModel : IEntityModel
    {
        public int Id { get; protected set; }
        public string Log { get; set; }
        public DateTime Time { get; set; }
    }
}
