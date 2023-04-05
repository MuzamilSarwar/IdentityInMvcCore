using System.ComponentModel.DataAnnotations;

namespace IdentityCore.Models
{
    public class SignUpDto
    {
        [Required(ErrorMessage ="Email Field is Required")]
        [Display(Name = "Email Address")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage ="Password is Required")]
        [Display(Name ="Password")]
        [Compare("ConfirmPassword", ErrorMessage = "Password Doesnot Match")]
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please Conform your Password")]
        [Display(Name = "Conform Password")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; } = string.Empty;
    }
}
