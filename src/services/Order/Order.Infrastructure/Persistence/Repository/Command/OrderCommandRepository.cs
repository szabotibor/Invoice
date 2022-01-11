using Order.Application.Repository.Abstraction;
using Product.Infrastructure.Persistence.Repository.Command.Base;

namespace Order.Infrastructure.Persistence.Repository.Command
{
    public class OrderCommandRepository : CommandRepositoryBase<Order.Domain.Entity.Order>, IOrderCommandRepository
    {
        public OrderCommandRepository(OrderDbContext context) : base(context)
        {
        }
    }
}