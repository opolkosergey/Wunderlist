using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entities
{
    public  class UserProfileModel : IEntity
    {
        [ForeignKey("UserModel")]
        public int ID { get; set; }
        public string Name { get; set; }
        public byte[] Photo { get; set; }

        public UserModel UserModel { get; set; }
    }
}
