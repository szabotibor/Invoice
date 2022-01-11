using Order.Application.Dto;
using Store.Application.Messaging.Base;

namespace Order.Application.Messaging.Commands
{
    public class AddOrderCommand: CommandWithResponseBase<AddOrderDto, int>
    {
        public AddOrderCommand(AddOrderDto data) : base(data)
        {
        }
    }
}