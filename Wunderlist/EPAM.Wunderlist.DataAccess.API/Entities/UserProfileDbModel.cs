namespace EPAM.Wunderlist.DataAccess.API.Entities
{
    public  class UserProfileDbModel : IEntityDb
    {
        public int ID { get; protected set; }
        public string Name { get; set; }
        public byte[] Photo { get; set; }

        public UserDbModel UserModel { get; set; }
    }
}
