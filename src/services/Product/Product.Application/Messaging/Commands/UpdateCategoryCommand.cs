using Product.Application.Dto;
using Product.Application.Messaging.Base;

namespace Product.Application.Messaging.Commands
{
    public class UpdateCategoryCommand : CommandBase<CategoryDto>
    {
        public UpdateCategoryCommand(CategoryDto data) : base(data)
        {
        }
    }
}