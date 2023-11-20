using CatenaccioStore.Application.Services.Products.DTOs;
using FluentValidation;

namespace CatenaccioStore.Application.Infrastruture.Validators.Products
{
    public class ProductRequestValidator : AbstractValidator<CreationProductDto>
    {
        public ProductRequestValidator()
        {
            RuleFor(i => i.ProductName).MinimumLength(2).NotEmpty();
            RuleFor(i => i.ShortTitle).MinimumLength(10).MaximumLength(50).NotEmpty();
            RuleFor(i => i.Brand).MinimumLength(2).NotEmpty();
            RuleFor(i => i.Description).MinimumLength(20).MaximumLength(200).NotEmpty();
        }
    }
}
