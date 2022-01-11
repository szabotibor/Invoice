using Product.Application.Repository.Abstraction;
using Product.Domain.Entity;
using Product.Infrastructure.Persistence.Repository.Command.Base;

namespace Product.Infrastructure.Persistence.Repository.Command
{
    public class CategoryCommandRepository : CommandRepositoryBase<Category>, ICategoryCommandRepository
    {
        public CategoryCommandRepository(ProductDbContext context) : base(context)
        {
        }
    }
}