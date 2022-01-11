using Ardalis.GuardClauses;
using AutoMapper;
using FluentResults;
using Microsoft.Extensions.Logging;
using Product.Application.Dto;
using Product.Application.Messaging.Base;
using Product.Application.Messaging.Queries;
using Product.Application.Repository.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Product.Application.Messaging.QueryHandlers
{
    public class GetAllProductsQueryHandler : HandlerWithResponseBase<GetAllProductsQuery, List<ProductDto>>
    {
        private readonly IProductQueryRepository _productQueryRepository;

        public GetAllProductsQueryHandler(IProductQueryRepository productQueryRepository, IMapper mapper, ILogger<GetAllProductsQueryHandler> logger ):base(mapper, logger)
        {
            _productQueryRepository = Guard.Against.Null(productQueryRepository, nameof(productQueryRepository));
        }
        public override async Task<Result<List<ProductDto>>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var entities = await _productQueryRepository.GetAllAsync(cancellationToken);
                var result = Mapper.Map<List<ProductDto>>(entities);
                
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
