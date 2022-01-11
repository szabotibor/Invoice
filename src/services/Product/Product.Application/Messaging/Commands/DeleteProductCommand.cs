using Product.Application.Messaging.Base;

namespace Product.Application.Messaging.Commands
{
    public class DeleteProductCommand : CommandBase<int>
    {
        public DeleteProductCommand(int data) : base(data)
        {
        }
    }
}