using Product.Application.Repository.Abstraction;
using Product.Domain.Entity;
using Product.Infrastructure.Persistence.Repository.Command.Base;

namespace Product.Infrastructure.Persistence.Repository.Command
{
    public class ProductCommandRepository : CommandRepositoryBase<Domain.Entity.Product>, IProductCommandRepository
    {
        public ProductCommandRepository(ProductDbContext context) : base(context)
        {
        }
    }
}