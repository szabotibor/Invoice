using System.Collections.Generic;
using FluentResults;
using MediatR;
using Product.Application.Dto;

namespace Product.Application.Messaging.Queries
{
    public class GetCategoriesQuery:IRequest<Result<List<CategoryDto>>>
    {
        
    }
}