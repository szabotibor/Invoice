using Store.Application.Dto;
using Store.Application.Messaging.Base;

namespace Store.Application.Messaging.Commands
{
    public class AddStoreCommand : CommandWithResponseBase<AddStorePayload, int>
    {
        public AddStoreCommand(AddStorePayload data) : base(data)
        {
        }
    }
}