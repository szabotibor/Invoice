using System;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.GuardClauses;
using AutoMapper;
using FluentResults;
using Microsoft.Extensions.Logging;
using Store.Application.Dto;
using Store.Application.Messaging.Base;
using Store.Application.Messaging.Queries;
using Store.Application.Repository.Abstraction;

namespace Store.Application.Messaging.QueryHandlers
{
    public class GetMyStoreQueryHandler:HandlerWithResponseBase<GetMyStoreQuery, StoreDto>
    {
        private readonly IStoreQueryRepository _storeQueryRepository;

        public GetMyStoreQueryHandler(IStoreQueryRepository storeQueryRepository, IMapper mapper, ILogger<GetMyStoreQueryHandler> logger) : base(mapper, logger)
        {
            _storeQueryRepository = Guard.Against.Null(storeQueryRepository, nameof(storeQueryRepository));
        }

        public override async Task<Result<StoreDto>> Handle(GetMyStoreQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _storeQueryRepository.GetMyStore( cancellationToken);
                return Result.Ok(Mapper.Map<StoreDto>(result));
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