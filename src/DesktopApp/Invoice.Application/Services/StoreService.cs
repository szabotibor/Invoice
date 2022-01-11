using FluentResults;
using Invoice.Application.Clients;
using Invoice.Application.Dto;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Invoice.Application.Services
{
    class StoreService:IStoreService
    {
        private readonly IStoreClient storeClient;

        public StoreService(IStoreClient storeClient)
        {
            this.storeClient = storeClient;
        }

        public async Task<Result<StoreDto?>> GetMyStore(CancellationToken cancellationToken)
        {
            try
            {
                var store = await storeClient.GetMyStoreAsync(cancellationToken);
                return Result.Ok(store);
            }
            catch (Exception ex)
            {
                var errorMessage = $"Error occured while fetching data. ({ex.Message})";
                return Result.Fail(errorMessage);
            }
        }

        public async Task<Result> UpdateMyStore(StoreDto store, CancellationToken cancellationToken)
        {
            return await storeClient.UpdateMyStoreAsync(store, cancellationToken);
        }

        public async Task<Result> UpdateStore(StoreDto store, CancellationToken cancellationToken)
        {
            return await storeClient.UpdateStoreAsync(store, cancellationToken);
        }

        public async Task<Result> DeleteStore(int id, CancellationToken cancellationToken)
        {
            return await storeClient.DeleteStore(id, cancellationToken);
        }

        public async Task<Result<List<StoreDto>>> GetStores(CancellationToken cancellationToken)
        {
            return await storeClient.GetStores(cancellationToken);
        }

        public async Task<Result> AddStore(StoreDto store, CancellationToken cancellationToken)
        {
            return await storeClient.AddStore(store, cancellationToken);
        }
    }
}
