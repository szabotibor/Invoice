using Store.Application.Repository;
using Store.Infrastructure.Persistence.Repository.Command.Base;

namespace Store.Infrastructure.Persistence.Repository.Command
{
    public class StoreCommandRepository : CommandRepositoryBase<Domain.Entity.Store>, IStoreCommandRepository
    {
        public StoreCommandRepository(StoreDbContext context) : base(context)
        {
        }
    }
}