﻿using System.ComponentModel.DataAnnotations;

namespace CatenaccioStore.Application.Services.Accounts.DTOs
{
    public class RegisterDto
    {
        [Display(Name = "Email")]
        [Required(ErrorMessage = "Email is required")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Email must be in correct format")]
        public string Email { get; set; }
        [Display(Name = "UserName")]
        [Required(ErrorMessage = "UserName is required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Minimum Length must be at least 3 and maximum 50 strongly typed characters!")]
        public string UserName { get; set; }
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name = "ConfirmPassword")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "ConfirmPassword is required!")]
        [Compare("Password", ErrorMessage = "Passwords do not match")]
        public string ConfirmPassword { get; set; }
        [Display(Name = "UserName")]
        [Required(ErrorMessage = "UserName is required")]
        public string FirstName { get; set; }
        [Display(Name = "UserName")]
        [Required(ErrorMessage = "UserName is required")]
        public string LastName { get; set; }
        [Display(Name = "UserName")]
        [Required(ErrorMessage = "UserName is required")]
        public DateTimeOffset DOB { get; set; }
        [Display(Name = "UserName")]
        [Required(ErrorMessage = "UserName is required")]
        public string PhoneNumber { get; set; }
        public string Gender { get; set; }

    }
}
