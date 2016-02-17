namespace ORM.Entities
{
    public  class UserProfile : IEntityDb
    {
        public int ID { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public byte[] Photo { get; set; }
    }
}
