using System.ComponentModel.DataAnnotations;

namespace CatenaccioStore.Application.Services.Accounts.DTOs
{
    public class LoginDto
    {
        [Display(Name = "Email")]
        [Required(ErrorMessage = "Email is required")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Must be in email format")]
        public string Email { get; set; }
        [Display(Name = "Password")]
        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
