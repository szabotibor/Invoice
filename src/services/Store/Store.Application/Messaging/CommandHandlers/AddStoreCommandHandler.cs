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
    public class AddStoreCommandHandler : HandlerWithResponseBase<AddStoreCommand, int>
    {
        private IStoreCommandRepository StoreCommandRepository { get; }

        public AddStoreCommandHandler(IStoreCommandRepository storeCommandRepository, IMapper mapper,
            ILogger<AddStoreCommandHandler> logger) : base(mapper, logger)
        {
            StoreCommandRepository = Guard.Against.Null(storeCommandRepository, nameof(storeCommandRepository));
        }

        public override async Task<Result<int>> Handle(AddStoreCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = Mapper.Map<Domain.Entity.Store>(request.Data);
                var result = await StoreCommandRepository.AddAsync(entity, cancellationToken);

                return Result.Ok(result.Id);
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