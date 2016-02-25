namespace EPAM.Wunderlist.Services.ServiceObjects
{
    public class UserServiceObject
    {
        public UserServiceObject(int id = 0)
        {
            Id = id;
        }

        public int Id { get; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
