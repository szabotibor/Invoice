using Store.Application.Dto;
using Store.Application.Messaging.Base;

namespace Store.Application.Messaging.Commands
{
    public class UpdateStoreCommand : CommandBase<UpdateStorePayload>
    {
        public UpdateStoreCommand(UpdateStorePayload data) : base(data)
        {
        }
    }
}