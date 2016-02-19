namespace DAL.Entities
{
    public  class UserProfileModel : IEntity
    {
        public int ID { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public byte[] Photo { get; set; }
    }
}
