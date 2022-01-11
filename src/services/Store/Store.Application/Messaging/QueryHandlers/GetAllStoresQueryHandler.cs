using System;
using System.Collections.Generic;
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
    public class GetAllStoresQueryHandler : HandlerWithResponseBase<GetAllStoresQuery, IReadOnlyList<StoreDto>>
    {
        private readonly IStoreQueryRepository _storeQueryRepository;

        public GetAllStoresQueryHandler(IStoreQueryRepository storeQueryRepository, IMapper mapper,
            ILogger<GetAllStoresQueryHandler> logger) : base(mapper, logger)
        {
            _storeQueryRepository = Guard.Against.Null(storeQueryRepository, nameof(storeQueryRepository));
        }

        public override async Task<Result<IReadOnlyList<StoreDto>>> Handle(GetAllStoresQuery request,
            CancellationToken cancellationToken)
        {
            try
            {
                var stores = await _storeQueryRepository.GetAllAsync(cancellationToken);
                var result = Mapper.Map<IReadOnlyList<StoreDto>>(stores);
                return Result.Ok(result);
            }
            catch (Exception ex)
            {
                var errorMessage = $"Error occured while retrieving data! ({ex.Message})";
                Logger.LogError(ex, errorMessage);
                return Result.Fail(errorMessage);
            }
        }
    }
}