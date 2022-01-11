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
    public class AddCategoryCommandHandler:HandlerWithResponseBase<AddCategoryCommand, int>
    {
        private readonly ICategoryCommandRepository _categoryCommandRepository;

        public AddCategoryCommandHandler(ICategoryCommandRepository categoryCommandRepository, IMapper mapper, ILogger<AddCategoryCommandHandler> logger) : base(mapper, logger)
        {
            _categoryCommandRepository = Guard.Against.Null(categoryCommandRepository, nameof(categoryCommandRepository));
        }

        public override async Task<Result<int>> Handle(AddCategoryCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = Mapper.Map<Category>(request.Data);
                var result = await _categoryCommandRepository.AddAsync(entity, cancellationToken);

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