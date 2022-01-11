using System.Collections.Generic;
using FluentResults;
using MediatR;
using Store.Application.Dto;

namespace Store.Application.Messaging.Queries
{
    public class GetAllStoresQuery : IRequest<Result<IReadOnlyList<StoreDto>>>
    {
        public GetAllStoresQuery()
        {
        }
    }
}