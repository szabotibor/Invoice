using Product.Application.Messaging.Base;

namespace Product.Application.Messaging.Commands
{
    public class DeleteCategoryCommand : CommandBase<int>
    {
        public DeleteCategoryCommand(int data) : base(data)
        {
        }
    }
}