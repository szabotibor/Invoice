using Product.Application.Dto;
using Product.Application.Messaging.Base;

namespace Product.Application.Messaging.Commands
{
    public class UpdateProductCommand : CommandBase<ProductDto>
    {
        public UpdateProductCommand(ProductDto data) : base(data)
        {
        }
    }
}