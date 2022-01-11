using FluentValidation;
using Store.Application.Dto;

namespace Store.Application.Validation
{
    public class AddStorePayloadValidator : AbstractValidator<AddStorePayload>
    {
        public AddStorePayloadValidator()
        {
            RuleFor(x => x)
                .NotNull()
                .WithMessage("No instance present");
            RuleFor(x => x.Name)
                .MinimumLength(1)
                .MaximumLength(255);
            RuleFor(x => x.Phone)
                .MinimumLength(1)
                .MaximumLength(15);
            RuleFor(x => x.Address)
                .MinimumLength(1)
                .MaximumLength(255);
            RuleFor(x => x.ContactName)
                .MaximumLength(255);
            RuleFor(x => x.ContactPhone)
                .MaximumLength(15);
            RuleFor(x => x.Detail)
                .MaximumLength(255);
            RuleFor(x => x.Fax)
                .MaximumLength(15);
        }
    }
}