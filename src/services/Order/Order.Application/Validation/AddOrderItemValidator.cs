using FluentValidation;
using Order.Application.Dto;

namespace Order.Application.Validation
{
    public class AddOrderItemValidator : AbstractValidator<AddOrderItemDto>
    {
        public AddOrderItemValidator()
        {
            RuleFor(x => x)
                .NotNull()
                .WithMessage("No instance present");

            RuleFor(x => x.ProductId)
                .GreaterThan(0);

            RuleFor(x => x.Box)
                .GreaterThanOrEqualTo(0);
            RuleFor(x => x.Each)
                .GreaterThanOrEqualTo(0);
            RuleFor(x => x.Pound)
                .GreaterThanOrEqualTo(0);
            RuleFor(x => x.Price)
                .GreaterThanOrEqualTo(0);
            RuleFor(x => x.Market)
                .MaximumLength(50);
            RuleFor(x => x.Note)
                .MaximumLength(255);
            RuleFor(x => x.RouteId)
                .GreaterThan(0);

        }
    }
}