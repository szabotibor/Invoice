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
using Store.Application.Repository.Abstraction;

namespace Store.Application.Messaging.CommandHandlers
{
    public class DeleteStoreCommandHandler : HandlerBase<DeleteStoreCommand>
    {
        private readonly IStoreCommandRepository _storeCommandRepository;
        private readonly IStoreQueryRepository _storeQueryRepository;

        public DeleteStoreCommandHandler(IStoreCommandRepository storeCommandRepository,
            IStoreQueryRepository storeQueryRepository, IMapper mapper, ILogger<DeleteStoreCommandHandler> logger) :
            base(mapper, logger)
        {
            _storeCommandRepository = Guard.Against.Null(storeCommandRepository, nameof(storeCommandRepository));
            _storeQueryRepository = Guard.Against.Null(storeQueryRepository, nameof(storeQueryRepository));
        }

        public override async Task<Result> Handle(DeleteStoreCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = await _storeQueryRepository.GetByIdAsync(request.Data, cancellationToken);
                
                if(entity is not null)
                    await _storeCommandRepository.DeleteAsync(entity, cancellationToken);
                
                return Result.Ok();
            }
            catch (Exception ex)
            {
                var errorMessage = $"Error occured while delete! ({ex.Message})";
                Logger.LogError(ex, errorMessage);
                return Result.Fail(errorMessage);
            }
        }
    }
}