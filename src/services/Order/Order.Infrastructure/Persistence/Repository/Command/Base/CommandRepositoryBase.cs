using System.Threading;
using System.Threading.Tasks;
using Ardalis.GuardClauses;
using Microsoft.EntityFrameworkCore;
using Order.Application.Repository.Abstraction;
using Order.Infrastructure.Persistence;

namespace Product.Infrastructure.Persistence.Repository.Command.Base
{
    public class CommandRepositoryBase<T> : ICommandRepository<T> where T : class
    {
        protected readonly OrderDbContext _context;

        public CommandRepositoryBase(OrderDbContext context)
        {
            _context = Guard.Against.Null(context, nameof(context));
        }

        public async Task<T> AddAsync(T entity, CancellationToken cancellationToken)
        {
            await _context.Set<T>().AddAsync(entity, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return entity;
        }

        public async Task UpdateAsync(T entity, CancellationToken cancellationToken)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteAsync(T entity, CancellationToken cancellationToken)
        {
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}