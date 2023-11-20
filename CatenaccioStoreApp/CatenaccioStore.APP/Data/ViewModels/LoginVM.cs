using System.ComponentModel.DataAnnotations;

namespace CatenaccioStore.APP.Data.ViewModels
{
    public class LoginVM
    {
        
        [Required(ErrorMessage = "Email is Required")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password is Required")]
        public string Password { get; set; }
    }
}
