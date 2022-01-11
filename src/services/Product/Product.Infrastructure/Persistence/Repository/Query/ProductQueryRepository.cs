using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Product.Application.Repository.Abstraction;
using Product.Domain.Entity;
using Product.Infrastructure.Persistence.Repository.Query.Base;

namespace Product.Infrastructure.Persistence.Repository.Query
{
    public class ProductQueryRepository : QueryRepositoryBase<Domain.Entity.Product>, IProductQueryRepository
    {
        public ProductQueryRepository(ProductDbContext context) : base(context)
        {
        }

        public async Task<IReadOnlyList<Domain.Entity.Product>> GetAllAsync(CancellationToken cancellationToken)
        {
            var result = await _context.Products.ToListAsync(cancellationToken);

            return result;
        }

        public async Task<Domain.Entity.Product?> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            var result = await _context
                .Products
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync(cancellationToken);

            return result;
        }
    }
}