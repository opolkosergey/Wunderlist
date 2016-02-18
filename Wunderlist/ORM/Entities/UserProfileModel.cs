using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ORM.Entities
{
    public  class UserProfileModel : IEntityDb
    {
        [Key]
        [ForeignKey("UserModel")]
        public int ID { get; set; }

        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
        public byte[] Photo { get; set; }

        public UserModel User { get; set; }
    }
}
