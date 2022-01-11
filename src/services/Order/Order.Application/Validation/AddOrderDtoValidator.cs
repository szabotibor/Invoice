using FluentValidation;
using Order.Application.Dto;

namespace Order.Application.Validation
{
    public class AddOrderDtoValidator : AbstractValidator<AddOrderDto>
    {
        public AddOrderDtoValidator()
        {
            RuleFor(x => x)
                .NotNull()
                .WithMessage("No instance present");

            RuleFor(x => x.StoreId)
                .GreaterThan(0);

            RuleFor(x => x.OrderDate)
                .NotNull();
            
            RuleFor(x => x.DeliveryDate)
                .GreaterThanOrEqualTo(x => x.OrderDate);

            RuleFor(x => x.Total)
                .GreaterThanOrEqualTo(0);
            
            RuleFor(x => x.Items)
                .NotEmpty();
        }
    }
}