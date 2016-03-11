namespace EPAM.Wunderlist.Model
{
    public class UserProfileModel : IEntityModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Photo { get; set; }
        public UserModel UserModel { get; set; }
    }
}
