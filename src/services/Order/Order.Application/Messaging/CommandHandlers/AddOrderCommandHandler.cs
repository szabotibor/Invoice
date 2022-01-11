using System;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.GuardClauses;
using AutoMapper;
using FluentResults;
using JetBrains.Annotations;
using Microsoft.Extensions.Logging;
using Order.Application.Messaging.Base;
using Order.Application.Messaging.Commands;
using Order.Application.Repository.Abstraction;

namespace Order.Application.Messaging.CommandHandlers
{
    public class AddOrderCommandHandler: HandlerWithResponseBase<AddOrderCommand, int>
    {
        private readonly IOrderCommandRepository _orderCommandRepository;

        public AddOrderCommandHandler(IOrderCommandRepository orderCommandRepository, IMapper mapper, ILogger logger) : base(mapper, logger)
        {
            _orderCommandRepository = Guard.Against.Null(orderCommandRepository, nameof(orderCommandRepository));
        }

        public override async Task<Result<int>> Handle(AddOrderCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = Mapper.Map<Domain.Entity.Order>(request.Data);
                var result = await _orderCommandRepository.AddAsync(entity, cancellationToken);
                return Result.Ok(result.Id);
            }
            catch (Exception ex)
            {
                var errorMessage = $"Error occured while saving data. ({ex.Message})";
                Logger.LogError(ex, errorMessage);
                return Result.Fail(errorMessage);
            }
        }
    }
}