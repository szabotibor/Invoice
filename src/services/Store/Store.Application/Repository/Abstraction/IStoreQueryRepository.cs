using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Store.Application.Repository.Abstraction
{
    public interface IStoreQueryRepository : IQueryRepository<Domain.Entity.Store>
    {
        Task<IReadOnlyList<Domain.Entity.Store>> GetAllAsync(CancellationToken cancellationToken);
        Task<Domain.Entity.Store?> GetByIdAsync(int id, CancellationToken cancellationToken);
        Task<Domain.Entity.Store> GetMyStore(CancellationToken cancellationToken);
    }
}