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
    public class CategoryQueryRepository : QueryRepositoryBase<Category>, ICategoryQueryRepository
    {
        public CategoryQueryRepository(ProductDbContext context) : base(context)
        {
        }

        public async Task<IReadOnlyList<Category>> GetAllAsync(CancellationToken cancellationToken)
        {
            var result = await _context.Categories.ToListAsync(cancellationToken);

            return result;
        }

        public async Task<Domain.Entity.Category?> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            var result = await _context
                .Categories
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync(cancellationToken);

            return result;
        }
    }
}