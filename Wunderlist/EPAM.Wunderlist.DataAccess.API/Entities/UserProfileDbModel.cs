namespace EPAM.Wunderlist.DataAccess.API.Entities
{
    public  class UserProfileDbModel : IEntityDb
    {
        public UserProfileDbModel(int id = 0)
        {
            ID = id;
        }
        
        public int ID { get; set; }
        public string Name { get; set; }
        public byte[] Photo { get; set; }

        public UserDbModel UserModel { get; set; }
    }
}
