using Ardalis.GuardClauses;
using Store.Application.Repository.Abstraction;

namespace Store.Infrastructure.Persistence.Repository.Query.Base
{
    public class QueryRepositoryBase<T> : IQueryRepository<T> where T : class
    {
        protected readonly StoreDbContext _context;

        public QueryRepositoryBase(StoreDbContext context)
        {
            _context = Guard.Against.Null(context, nameof(context));
        }
    }
}