using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Store.Application.Repository.Abstraction;
using Store.Infrastructure.Persistence.Repository.Query.Base;

namespace Store.Infrastructure.Persistence.Repository.Query
{
    public class StoreQueryRepository : QueryRepositoryBase<Domain.Entity.Store>, IStoreQueryRepository
    {
        public StoreQueryRepository(StoreDbContext context) : base(context)
        {
        }

        public async Task<IReadOnlyList<Domain.Entity.Store>> GetAllAsync(CancellationToken cancellationToken)
        {
            var result = await _context.Stores.Where(x=>!x.IsMyStore).ToListAsync(cancellationToken);

            return result;
        }

        public async Task<Domain.Entity.Store?> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            var result = await _context
                .Stores
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync(cancellationToken);

            return result;
        }

        public async Task<Domain.Entity.Store> GetMyStore(CancellationToken cancellationToken)
        {
            var result = await _context
                .Stores
                .Where(x => x.IsMyStore == true)
                .FirstAsync(cancellationToken);

            return result;
        }
    }
}