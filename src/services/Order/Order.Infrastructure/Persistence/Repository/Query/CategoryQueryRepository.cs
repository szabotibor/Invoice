using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Order.Application.Repository.Abstraction;
using Product.Infrastructure.Persistence.Repository.Query.Base;

namespace Order.Infrastructure.Persistence.Repository.Query
{
    public class OrderQueryRepository : QueryRepositoryBase<Domain.Entity.Order>, IOrderQueryRepository
    {
        public OrderQueryRepository(OrderDbContext context) : base(context)
        {
        }

        public async Task<IReadOnlyList<Domain.Entity.Order>> GetAllAsync(CancellationToken cancellationToken)
        {
            var result = await _context.Orders.ToListAsync(cancellationToken);

            return result;
        }

        public async Task<Domain.Entity.Order?> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            var result = await _context
                .Orders
                .Include(x=>x.Items)
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync(cancellationToken);

            return result;
        }
    }
}