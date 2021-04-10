using FluentValidation;
using StoreKeeper.Services.DTOs;
using StoreKeeper.Core.Models;

namespace StoreKeeper.Services.Validators
{
    public class ProductGroupSaveDTOValidator : AbstractValidator<ProductGroupSaveDTO>
    {
        public ProductGroupSaveDTOValidator()
        {
            RuleFor(a => a.Name)
                .NotEmpty()
                .WithMessage("Name must not be empty");
            
            RuleFor(a => a.Name)
                .MaximumLength(ProductGroup.NameMaxLength)
                .WithMessage("Name must not exceed " + ProductGroup.NameMaxLength + " characters");

            RuleFor(a => a.Code)
                .NotEmpty()
                .WithMessage("Code must not be empty");

            RuleFor(a => a.Code)
                .MaximumLength(ProductGroup.CodeMaxLength)
                .WithMessage("Code must not exceed " + ProductGroup.CodeMaxLength + " characters");

            RuleFor(a => a.Description)
                .NotEmpty()
                .WithMessage("Description must not be empty");
                
            RuleFor(a => a.Description)
                .MaximumLength(ProductGroup.DescriptionMaxLength)
                .WithMessage("Description must not exceed " + ProductGroup.DescriptionMaxLength + " characters");
        }
    }
}
