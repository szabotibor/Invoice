using System;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.GuardClauses;
using AutoMapper;
using FluentResults;
using Microsoft.Extensions.Logging;
using Store.Application.Messaging.Base;
using Store.Application.Messaging.Commands;
using Store.Application.Repository;

namespace Store.Application.Messaging.CommandHandlers
{
    public class UpdateStoreCommandHandler : HandlerBase<UpdateStoreCommand>
    {
        private IStoreCommandRepository StoreCommandRepository { get; }

        public UpdateStoreCommandHandler(IStoreCommandRepository storeCommandRepository, IMapper mapper,
            ILogger<UpdateStoreCommandHandler> logger) : base(mapper, logger)
        {
            StoreCommandRepository = Guard.Against.Null(storeCommandRepository, nameof(storeCommandRepository));
        }

        public override async Task<Result> Handle(UpdateStoreCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = Mapper.Map<Domain.Entity.Store>(request.Data);
                await StoreCommandRepository.UpdateAsync(entity, cancellationToken);
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