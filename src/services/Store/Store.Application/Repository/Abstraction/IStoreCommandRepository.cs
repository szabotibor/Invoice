using FluentResults;
using Store.Application.Repository.Abstraction;

namespace Store.Application.Repository
{
    public interface IStoreCommandRepository : ICommandRepository<Domain.Entity.Store>
    {

    }
}