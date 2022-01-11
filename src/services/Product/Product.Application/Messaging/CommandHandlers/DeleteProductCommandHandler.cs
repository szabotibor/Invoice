using System;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.GuardClauses;
using AutoMapper;
using FluentResults;
using JetBrains.Annotations;
using Microsoft.Extensions.Logging;
using Product.Application.Messaging.Base;
using Product.Application.Messaging.Commands;
using Product.Application.Repository.Abstraction;

namespace Product.Application.Messaging.CommandHandlers
{
    public class DeleteProductCommandHandler:HandlerBase<DeleteProductCommand>
    {
        private readonly IProductQueryRepository _productQueryRepository;
        private readonly IProductCommandRepository _productCommandRepository;

        public DeleteProductCommandHandler(IProductCommandRepository productCommandRepository, IProductQueryRepository productQueryRepository, IMapper mapper, ILogger<DeleteCategoryCommandHandler> logger) : base(mapper, logger)
        {
            _productQueryRepository = Guard.Against.Null(productQueryRepository, nameof(productQueryRepository));
            _productCommandRepository =  Guard.Against.Null(productCommandRepository, nameof(productCommandRepository));
        }

        public override async Task<Result> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = await _productQueryRepository.GetByIdAsync(request.Data, cancellationToken);

                if (entity is not null)
                    await _productCommandRepository.DeleteAsync(entity, cancellationToken);

                return Result.Ok();
            }
            catch (Exception ex)
            {
                var errorMessage = $"Error occured while delete. ({ex.Message})";
                Logger.LogError(ex, errorMessage);
                return Result.Fail(errorMessage);
            }
        }
    }
}