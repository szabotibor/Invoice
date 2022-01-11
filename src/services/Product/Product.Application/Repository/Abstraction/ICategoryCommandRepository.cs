using Product.Domain.Entity;
using Store.Application.Repository.Abstraction;

namespace Product.Application.Repository.Abstraction
{
    public interface ICategoryCommandRepository : ICommandRepository<Category>
    {

    }
}