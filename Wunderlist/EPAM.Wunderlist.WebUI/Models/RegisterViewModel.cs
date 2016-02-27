using System.ComponentModel.DataAnnotations;

namespace EPAM.Wunderlist.WebUI.Models
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "The field Name must not be empty!")]
        [StringLength(30, ErrorMessage = "Name must contains at least {2} characters", MinimumLength = 2)]
        public string Name { get; set; }

        [Required(ErrorMessage = "The field Email must not be empty!")]
        [StringLength(30, ErrorMessage = "Email must contain at least {2} characters", MinimumLength = 7)]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"^([a-z0-9_-]+\.)*[a-z0-9_-]+@[a-z0-9_-]+(\.[a-z0-9_-]+)*\.[a-z]{2,6}$")]
        public string Email { get; set; }

        [Required]
        [StringLength(20, ErrorMessage = "Name must contains at least {2} characters", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}