using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.GuardClauses;
using AutoMapper;
using FluentResults;
using Microsoft.Extensions.Logging;
using Store.Application.Messaging.Base;
using Store.Application.Messaging.Commands;
using Store.Application.Repository;
using Store.Application.Repository.Abstraction;

namespace Store.Application.Messaging.CommandHandlers
{
    public class UpdateMyStoreCommandHandler : HandlerBase<UpdateMyStoreCommand>
    {
        private readonly IStoreCommandRepository _storeCommandRepository;
        private readonly IStoreQueryRepository _storeQueryRepository;

        public UpdateMyStoreCommandHandler(IStoreCommandRepository storeCommandRepository, IStoreQueryRepository storeQueryRepository, IMapper mapper, ILogger<UpdateMyStoreCommandHandler> logger): base(mapper, logger)
        {
            _storeCommandRepository = Guard.Against.Null(storeCommandRepository, nameof(storeCommandRepository));
            _storeQueryRepository = Guard.Against.Null(storeQueryRepository, nameof(storeQueryRepository));
        }

        public override async Task<Result> Handle(UpdateMyStoreCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = new Domain.Entity.Store(
                    id: request.Data.Id,
                    request.Data.Name,
                    request.Data.Phone,
                    request.Data.Address,
                    null,
                    null,
                    detail: request.Data.Detail,
                    fax: request.Data.Fax,
                    isMarket: 0,
                    isMyStore: true); ;

                await _storeCommandRepository.UpdateAsync(entity, cancellationToken);
                return Result.Ok();
            }
            catch (Exception ex)
            {
                var errorMessage = $"Error occured while saving data! ({ex.Message})";
                Logger.LogError(ex, errorMessage);
                return Result.Fail(errorMessage);
            }
        }
    }
}
