using FluentValidation;
using Product.Application.Dto;

namespace Product.Application.Validation
{
    public class CategoryDtoValidator : AbstractValidator<CategoryDto>
    {
        public CategoryDtoValidator()
        {
            RuleFor(x => x)
                .NotNull()
                .WithMessage("No instance present");
            RuleFor(x => x.Id)
                .GreaterThan(0);

            RuleFor(x => x.Name)
                .MinimumLength(1)
                .MaximumLength(255);

            RuleFor(x => x.SubCategoryName)
                .MinimumLength(1)
                .MaximumLength(255);
        }
    }
}