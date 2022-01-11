namespace Order.Application.Repository.Abstraction
{
    public interface IOrderCommandRepository: ICommandRepository<Domain.Entity.Order>
    {
        
    }
}