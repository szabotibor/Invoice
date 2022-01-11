using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Order.Application.Repository.Abstraction
{
    public interface IOrderQueryRepository: IQueryRepository<Domain.Entity.Order>
    {
        Task<IReadOnlyList<Domain.Entity.Order>> GetAllAsync(CancellationToken cancellationToken);
        Task<Domain.Entity.Order?> GetByIdAsync(int id, CancellationToken cancellationToken);
    }
}