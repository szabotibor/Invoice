using System;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.GuardClauses;
using AutoMapper;
using FluentResults;
using Microsoft.Extensions.Logging;
using Product.Application.Messaging.Base;
using Product.Application.Messaging.Commands;
using Product.Application.Repository.Abstraction;
using Product.Domain.Entity;

namespace Product.Application.Messaging.CommandHandlers
{
    public class UpdateProductCommandHandler : HandlerBase<UpdateProductCommand>
    {
        private readonly IProductCommandRepository _productCommandRepository;

        public UpdateProductCommandHandler(IProductCommandRepository productCommandRepository, IMapper mapper,
            ILogger<UpdateProductCommandHandler> logger) : base(mapper, logger)
        {
            _productCommandRepository = Guard.Against.Null(productCommandRepository, nameof(productCommandRepository));
        }

        public override async Task<Result> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = Mapper.Map<Domain.Entity.Product>(request.Data);
                await _productCommandRepository.UpdateAsync(entity, cancellationToken);
                return Result.Ok();
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