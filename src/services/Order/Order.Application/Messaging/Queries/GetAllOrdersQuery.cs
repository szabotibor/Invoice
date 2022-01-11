using System.Collections.Generic;
using FluentResults;
using MediatR;
using Order.Application.Dto;

namespace Order.Application.Messaging.Queries
{
    public class GetAllOrdersQuery: IRequest<Result<IList<OrderDto>>>
    {
        
    }
}