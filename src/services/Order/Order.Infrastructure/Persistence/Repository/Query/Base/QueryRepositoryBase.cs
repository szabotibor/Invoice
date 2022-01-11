using Ardalis.GuardClauses;
using Order.Application.Repository.Abstraction;
using Order.Infrastructure.Persistence;

namespace Product.Infrastructure.Persistence.Repository.Query.Base
{
    public class QueryRepositoryBase<T> : IQueryRepository<T> where T : class
    {
        protected readonly OrderDbContext _context;

        public QueryRepositoryBase(OrderDbContext context)
        {
            _context = Guard.Against.Null(context, nameof(context));
        }
    }
}