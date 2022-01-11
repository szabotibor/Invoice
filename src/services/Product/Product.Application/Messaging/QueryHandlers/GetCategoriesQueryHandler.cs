using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.GuardClauses;
using AutoMapper;
using FluentResults;
using Microsoft.Extensions.Logging;
using Product.Application.Dto;
using Product.Application.Messaging.Base;
using Product.Application.Messaging.Queries;
using Product.Application.Repository.Abstraction;

namespace Product.Application.Messaging.QueryHandlers
{
    public class GetCategoriesQueryHandler:HandlerWithResponseBase<GetCategoriesQuery, List<CategoryDto>>
    {
        private readonly ICategoryQueryRepository _categoryQueryRepository;

        public GetCategoriesQueryHandler(ICategoryQueryRepository categoryQueryRepository, IMapper mapper, ILogger<GetCategoriesQueryHandler> logger) : base(mapper, logger)
        {
            _categoryQueryRepository = Guard.Against.Null(categoryQueryRepository, nameof(categoryQueryRepository));
        }

        public override async Task<Result<List<CategoryDto>>> Handle(GetCategoriesQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var entities = await _categoryQueryRepository.GetAllAsync(cancellationToken);
                var result = Mapper.Map<List<CategoryDto>>(entities);

                return Result.Ok(result);
            }
            catch (Exception ex)
            {
                var errorMessage = $"Error occured while retrieving data. ({ex.Message})";
                Logger.LogError(ex, errorMessage);
                return Result.Fail(errorMessage);
            }
        }
    }
}