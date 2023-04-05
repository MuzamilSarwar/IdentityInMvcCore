using Microsoft.AspNetCore.Cors;
using System.ComponentModel.DataAnnotations;

namespace IdentityCore.Models
{
    public class SignInDto
    {
        [Required(ErrorMessage ="Email Field is required")]
        [DataType(DataType.EmailAddress)]
        [Display(Name ="Email")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Password Field is required")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; } = string.Empty;

        [Display(Name ="Remeber ME")]
        public bool RemaberMe { get; set; }
    }
}
