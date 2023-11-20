using CatenaccioStore.Application.Services.Accounts.DTOs;
using FluentValidation;


namespace CatenaccioStore.Application.Infrastruture.Validators.Account
{
    public class ProductRequestValidator : AbstractValidator<AccountDto>
    {
        public ProductRequestValidator()
        {
            RuleFor(i => i.Email).EmailAddress().WithMessage("Incorrect Format Of Email").NotEmpty();
            RuleFor(i => i.UserName).MinimumLength(2).MaximumLength(50).NotEmpty();
            RuleFor(i => i.LastName).MinimumLength(2).MaximumLength(50).NotEmpty();
            RuleFor(i => i.PhoneNumber).MinimumLength(2).MaximumLength(50).NotEmpty();
            RuleFor(i => i.Password).Matches("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[#$^+=!*()@%&]).{8,}$").WithMessage("Password must contain one lowwer case, one uppercase,one number,one special character and must be at least 8 characters length");
        }
    }
}
