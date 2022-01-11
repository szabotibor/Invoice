using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Store.Application.Repository.Abstraction;

namespace Product.Application.Repository.Abstraction
{
    public interface IProductQueryRepository : IQueryRepository<Domain.Entity.Product>
    {
        Task<IReadOnlyList<Domain.Entity.Product>> GetAllAsync(CancellationToken cancellationToken);
        Task<Domain.Entity.Product?> GetByIdAsync(int id, CancellationToken cancellationToken);
    }
}