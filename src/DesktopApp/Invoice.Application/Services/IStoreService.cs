using FluentResults;
using Invoice.Application.Dto;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Invoice.Application.Services
{
    public interface IStoreService
    {
        Task<Result> DeleteStore(int id, CancellationToken cancellationToken);
        Task<Result<StoreDto?>> GetMyStore(CancellationToken cancellationToken);
        Task<Result> UpdateMyStore(StoreDto store, CancellationToken cancellationToken);
        Task<Result<List<StoreDto>>> GetStores(CancellationToken cancellationToken);
        Task<Result> AddStore(StoreDto store, CancellationToken cancellationToken);
        Task<Result> UpdateStore(StoreDto store, CancellationToken cancellationToken);
    }
}