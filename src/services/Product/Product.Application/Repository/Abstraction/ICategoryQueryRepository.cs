using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Product.Domain.Entity;
using Store.Application.Repository.Abstraction;

namespace Product.Application.Repository.Abstraction
{
    public interface ICategoryQueryRepository : IQueryRepository<Category>
    {
        Task<IReadOnlyList<Category>> GetAllAsync(CancellationToken cancellationToken);
        Task<Category?> GetByIdAsync(int id, CancellationToken cancellationToken);
    }
}