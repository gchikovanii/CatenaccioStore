using System.ComponentModel.DataAnnotations;

namespace CatenaccioStore.APP.Data.ViewModels
{
    public class RegisterVM
    {
        [Required(ErrorMessage = "FirstName is Required")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "LastName is Required")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "UserName is Required")]

        public string UserName { get; set; }
        [Required(ErrorMessage = "DOB is Required")]
        public DateTimeOffset DOB { get; set; }
        [Required(ErrorMessage = "Email is Required")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password is Required")]
        public string Password { get; set; }
        [Required(ErrorMessage = "PhoneNumber is Required")]
        public string PhoneNumber { get; set; }

    }
}
