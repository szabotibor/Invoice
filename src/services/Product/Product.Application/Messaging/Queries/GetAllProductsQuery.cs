using FluentResults;
using MediatR;
using Product.Application.Dto;
using System.Collections.Generic;

namespace Product.Application.Messaging.Queries
{
    public class GetAllProductsQuery: IRequest<Result<List<ProductDto>>>
    {
    }
}
