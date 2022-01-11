using Ardalis.GuardClauses;
using Store.Application.Repository.Abstraction;

namespace Product.Infrastructure.Persistence.Repository.Query.Base
{
    public class QueryRepositoryBase<T> : IQueryRepository<T> where T : class
    {
        protected readonly ProductDbContext _context;

        public QueryRepositoryBase(ProductDbContext context)
        {
            _context = Guard.Against.Null(context, nameof(context));
        }
    }
}