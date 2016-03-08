namespace EPAM.Wunderlist.Model
{
    public  class UserProfileModel : IEntityModel
    {
        public int Id { get; protected set; }
        public string Name { get; set; }
        public byte[] Photo { get; set; }

        public UserModel UserModel { get; set; }
    }
}
