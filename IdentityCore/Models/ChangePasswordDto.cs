using System.ComponentModel.DataAnnotations;

namespace IdentityCore.Models
{
    public class ChangePasswordDto
    {
        [Required(ErrorMessage ="Please Enter Old Password")]
        [Display(Name = "Old Password")]
        public string OldPassword { get; set; } = string.Empty;

        [Required(ErrorMessage ="Please Enter New Password")]
        [Display(Name = "New Password")]
        [Compare("ConfirmNewPassword", ErrorMessage ="Password not Matched")]
        public string NewPassword { get; set; } = string.Empty;

        [Required(ErrorMessage = "Field Must not be empty")]
        [Display(Name = "Confirm New Password")]
        public string ConfirmNewPassword { get; set; } = string.Empty;
    }
}
