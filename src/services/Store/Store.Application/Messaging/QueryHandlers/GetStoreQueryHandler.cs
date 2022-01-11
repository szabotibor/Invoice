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
    public class GetStoreQueryHandler : HandlerWithResponseBase<GetStoreQuery, StoreDto>
    {
        private readonly IStoreQueryRepository _storeQueryRepository;

        public GetStoreQueryHandler(IStoreQueryRepository storeQueryRepository, IMapper mapper,
            ILogger<GetStoreQueryHandler> logger) : base(mapper, logger)
        {
            _storeQueryRepository = Guard.Against.Null(storeQueryRepository, nameof(storeQueryRepository));
        }

        public override async Task<Result<StoreDto>> Handle(GetStoreQuery request, CancellationToken cancellationToken)
        {
            var result = await _storeQueryRepository.GetByIdAsync(request.Data, cancellationToken);
            if (result is not null)
            {
                return Result.Ok(Mapper.Map<StoreDto>(result));
            }

            var errorMessage = $"NotFound";
            return Result.Fail(errorMessage);
        }
    }
}