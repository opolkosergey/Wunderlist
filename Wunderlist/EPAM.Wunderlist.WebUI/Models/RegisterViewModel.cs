using System.ComponentModel.DataAnnotations;

namespace EPAM.Wunderlist.WebUI.Models
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Name must not be empty!")]
        [StringLength(15, MinimumLength = 2, ErrorMessage = "Name must be 2 to 15 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email must not be empty!")]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"(?i)\b[A-Z0-9._%-]+@[A-Z0-9.-]+\.[A-Z]{2,4}\b", ErrorMessage = "Email address not valid! (example: Veniamin@gmail.com)")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password must not be empty!")]
        [StringLength(20, MinimumLength = 7, ErrorMessage = "Password must be 7 to 20 characters")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}