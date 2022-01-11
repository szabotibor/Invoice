using FluentValidation;
using Product.Application.Dto;

namespace Product.Application.Validation
{
    public class AddCategoryDtoValidator : AbstractValidator<AddCategoryDto>
    {
        public AddCategoryDtoValidator()
        {
            RuleFor(x => x)
                .NotNull()
                .WithMessage("No instance present");
            
            RuleFor(x => x.Name)
                .MinimumLength(1)
                .MaximumLength(255);
            
            RuleFor(x => x.SubCategoryName)
                .MinimumLength(1)
                .MaximumLength(255);
        }
    }
}