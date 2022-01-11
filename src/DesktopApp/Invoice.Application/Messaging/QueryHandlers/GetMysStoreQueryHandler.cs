using System;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.GuardClauses;
using AutoMapper;
using FluentResults;
using Invoice.Application.Clients;
using Invoice.Application.Dto;
using Invoice.Application.Messaging.Queries;
using Microsoft.Extensions.Logging;
using Product.Application.Messaging.Base;

namespace Invoice.Application.Messaging.QueryHandlers
{
    public class GetMyStoreQueryHandler : HandlerWithResponseBase<GetMyStoreQuery, StoreDto>
    {
        private readonly IStoreClient _storeClient;

        public GetMyStoreQueryHandler(IStoreClient storeClient, IMapper mapper, ILogger<GetMyStoreQueryHandler> logger) : base(mapper, logger)
        {
            _storeClient = Guard.Against.Null(storeClient, nameof(storeClient));
        }

        public override async Task<Result<StoreDto>> Handle(GetMyStoreQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var store = await _storeClient.GetMyStoreAsync(cancellationToken);
                return Result.Ok(store);
            }
            catch (Exception ex)
            {
                var errorMessage = $"Error occured while fetching data. ({ex.Message})";
                Logger.LogError(ex, errorMessage);
                return Result.Fail(errorMessage);
            }
        }
    }
}