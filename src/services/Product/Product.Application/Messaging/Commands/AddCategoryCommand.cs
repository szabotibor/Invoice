using Product.Application.Dto;
using Product.Application.Messaging.Base;

namespace Product.Application.Messaging.Commands
{
    public class AddCategoryCommand:CommandWithResponseBase<AddCategoryDto, int>
    {
        public AddCategoryCommand(AddCategoryDto data) : base(data)
        {
        }
    }
}