namespace EPAM.Wunderlist.DataAccess.API.Entities
{
    public class LogModel : IEntity
    {
        public LogModel(int id = 0)
        {
            ID = id;
        }

        public int ID { get; }
        public string Log { get; set; }
    }
}
