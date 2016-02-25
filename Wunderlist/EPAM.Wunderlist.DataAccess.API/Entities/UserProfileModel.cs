namespace EPAM.Wunderlist.DataAccess.API.Entities
{
    public  class UserProfileModel : IEntity
    {
        public UserProfileModel(int id = 0)
        {
            ID = id;
        }
        
        public int ID { get; set; }
        public string Name { get; set; }
        public byte[] Photo { get; set; }

        public UserModel UserModel { get; set; }
    }
}
