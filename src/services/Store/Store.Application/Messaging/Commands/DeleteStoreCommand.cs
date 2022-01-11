using Store.Application.Messaging.Base;

namespace Store.Application.Messaging.Commands
{
    public class DeleteStoreCommand : CommandBase<int>
    {
        public DeleteStoreCommand(int data) : base(data)
        {
        }
    }
}