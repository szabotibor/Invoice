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
    public class DeleteCategoryCommandHandler:HandlerBase<DeleteCategoryCommand>
    {
        private readonly ICategoryQueryRepository _categoryQueryRepository;
        private readonly ICategoryCommandRepository _categoryCommandRepository;

        public DeleteCategoryCommandHandler(ICategoryCommandRepository categoryCommandRepository, ICategoryQueryRepository categoryQueryRepository, IMapper mapper, ILogger<DeleteCategoryCommandHandler> logger) : base(mapper, logger)
        {
            _categoryQueryRepository = Guard.Against.Null(categoryQueryRepository, nameof(categoryQueryRepository));
            _categoryCommandRepository = Guard.Against.Null(categoryCommandRepository, nameof(categoryCommandRepository));
        }

        public override async Task<Result> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = await _categoryQueryRepository.GetByIdAsync(request.Data, cancellationToken);

                if (entity is not null)
                    await _categoryCommandRepository.DeleteAsync(entity, cancellationToken);

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