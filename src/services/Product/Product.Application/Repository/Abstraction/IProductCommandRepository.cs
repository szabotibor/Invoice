using Product.Domain.Entity;
using Store.Application.Repository.Abstraction;

namespace Product.Application.Repository.Abstraction
{
    public interface IProductCommandRepository : ICommandRepository<Domain.Entity.Product>
    {

    }
}