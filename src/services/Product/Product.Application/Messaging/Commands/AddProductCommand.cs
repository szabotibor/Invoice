using Product.Application.Dto;
using Product.Application.Messaging.Base;

namespace Product.Application.Messaging.Commands
{
    public class AddProductCommand : CommandWithResponseBase<AddProductDto, int>
    {
        public AddProductCommand(AddProductDto data) : base(data)
        {
        }
    }
}