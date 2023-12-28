using System.ComponentModel.DataAnnotations;

namespace OpenDHS.Web.Areas.Manage.Pages.User
{
    public class UserPageModel
    {
        public string Name { get; set; } = string.Empty;
        public string Lastname { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Contrasenna")]
        public string Password { get; set; } = string.Empty;

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; } = string.Empty;

    }
}
