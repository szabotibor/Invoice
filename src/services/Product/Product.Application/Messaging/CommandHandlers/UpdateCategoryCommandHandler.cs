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
    public class UpdateCategoryCommandHandler:HandlerBase<UpdateCategoryCommand>
    {
        private readonly ICategoryCommandRepository _categoryCommandRepository;

        public UpdateCategoryCommandHandler(ICategoryCommandRepository categoryCommandRepository, IMapper mapper, ILogger<UpdateCategoryCommandHandler> logger) : base(mapper, logger)
        {
            _categoryCommandRepository = Guard.Against.Null(categoryCommandRepository, nameof(categoryCommandRepository));
        }

        public override async Task<Result> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = Mapper.Map<Category>(request.Data);
                await _categoryCommandRepository.UpdateAsync(entity, cancellationToken);
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