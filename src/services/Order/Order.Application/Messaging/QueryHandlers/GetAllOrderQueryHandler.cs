using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FluentResults;
using JetBrains.Annotations;
using Microsoft.Extensions.Logging;
using Order.Application.Dto;
using Order.Application.Messaging.Base;
using Order.Application.Messaging.Queries;
using Order.Application.Repository.Abstraction;

namespace Order.Application.Messaging.QueryHandlers
{
    public class GetAllOrderQueryHandler: HandlerWithResponseBase<GetAllOrdersQuery, IList<OrderDto>>
    {
        private readonly IOrderQueryRepository _orderQueryRepository;

        public GetAllOrderQueryHandler(IOrderQueryRepository orderQueryRepository, IMapper mapper, ILogger logger) : base(mapper, logger)
        {
            _orderQueryRepository = orderQueryRepository;
        }

        public override async Task<Result<IList<OrderDto>>> Handle(GetAllOrdersQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var orders = await _orderQueryRepository.GetAllAsync(cancellationToken);
                var result = Mapper.Map<IList<OrderDto>>(orders);
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