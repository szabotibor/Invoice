using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using FluentResults;
using Invoice.Application.Dto;

namespace Invoice.Application.Clients
{
    public interface IStoreClient
    {
        Task<Result> AddStore(StoreDto store, CancellationToken cancellationToken);
        Task<Result> DeleteStore(int id, CancellationToken cancellationToken);
        Task<StoreDto?> GetMyStoreAsync(CancellationToken cancellationToken);
        Task<Result<List<StoreDto>>> GetStores(CancellationToken cancellationToken);
        Task<Result> UpdateMyStoreAsync(StoreDto store, CancellationToken cancellationToken);
        Task<Result> UpdateStoreAsync(StoreDto store, CancellationToken cancellationToken);
    }
}